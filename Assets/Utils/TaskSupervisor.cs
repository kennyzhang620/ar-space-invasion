using UnityEngine.EventSystems;
using UnityEngine;
using System.Collections.Generic;
//using OpenCover.Framework.Model;

public class FaultType
{
    public int DetectorID;
    public int expected;

    public FaultType(int did, int dexpected)
    {
        DetectorID = did;
        expected = dexpected;
    }
}

[RequireComponent(typeof(EventTrigger_C))]
public class TaskSupervisor : MonoBehaviour
{
    public string Name;
    EventTrigger_C PrereqsSetup;
    public EventTrigger_C[] StateChanges;
    public Detector[] Detectors;
    public float Weight;
    public int[] RequiredMissions;
    public bool TrackOnly;

    [HideInInspector]
    public QuestManager MM;
    public int CurrentStep = 0;
    [HideInInspector]
    public bool _missionComplete = false;
    // Other internal variables for every distinct TS

    List<float> _timestamps = new List<float>();
    Dictionary<FaultType, int> _faults = new Dictionary<FaultType, int>();

    float _time = 0;
    float _rtime = 0;
    bool _tracker = false;

    public void StartTimer()
    {
        CaptureTimestamp();
        _tracker = true;
        print("Started time tracking...");
    }

    public void StopTimer() { 
        _tracker = false;
        CaptureTimestamp();
        print("Stopped timer.");
    }

    public void CaptureTimestamp()
    {
        _timestamps.Add(_rtime);
        _timestamps.Add(_time);
        _rtime = 0;
        print("Timestamp captured.");
    }

    public void ResetTimer()
    {
        _time = 0;
        _rtime = 0;
        print("Timer reset.");
    }

    public void ClearTimestamps()
    {
        _timestamps.Clear();
        print("Timestamps cleared!");
    }

    public void PrintTimestamps()
    {
        string outstr = (Name + "--- START OF TIMESTAMPS ---\n");
        foreach (float ts in _timestamps)
        {
            outstr += (ts);
            outstr += "\n";
        }
        outstr += ("--- END OF TIMESTAMPS ---\n");

        print(outstr);
    }

    public void PrintCollisionCaptures()
    {
        string outstr = (Name + "--- START OF COLLISIONS ---\n");
        foreach (var res in _faults)
        {
            outstr += ("Detector: " + res.Key.DetectorID + " Expected: " + res.Key.expected + " Occurrences: "+ res.Value);
            outstr += "\n";
        }
        outstr += ("--- END OF COLLISIONS ---\n");

        print(outstr);
    }

    public void RecordCollider(int DetectorID, int expected)
    {
        FaultType faultType = new FaultType(DetectorID, expected);
        if (!_faults.ContainsKey(faultType))
            _faults.Add(faultType, 1);
        else
        {
            _faults[faultType]++;
        }
    }

    public float ComputeScoreForTask()
    {
        return Weight * CurrentStep;
    }

    public void ClearColliders()
    {
        _faults.Clear();
    }

    // Start construction of object and connect all Detectors to TS
    void _construct()
    {
        foreach (Detector d in Detectors)
        {
            if (d != null)
                d.assignedDM = this;
        }

        foreach (EventTrigger_C cv in StateChanges)
        {
            if (cv != null)
                cv.enabled = !TrackOnly;
        }

        LoadStep(CurrentStep);
    }

    // Disables all attached Detectors and StateChangers and disables itself
    void _disable()
    {
        foreach (Detector d in Detectors)
        {
            if (d != null)
                d.enabled = false;
        }

        foreach (EventTrigger_C t in StateChanges)
        {
            if (t != null)
                t.enabled = false;
        }

        this.enabled = false;
    }

    public virtual void LoadStep(int step)
    {
        if (!TrackOnly)
        {
            if (StateChanges != null && StateChanges[step] != null)
                StateChanges[step].Trigger();
        }

        PrereqsSetup.Trigger();
    }
    // Advance to the next step of the task
    public virtual void AdvanceStep(int id)
    {
        // condition for passing {
        CurrentStep++;
    }


    // Tell MM to advance to the next mission, call the disabler if true.
    public virtual bool NextMission()
    {
        // condition for progression {

        if (MM != null)
            MM.NextMission();
        return true;
    }

    void OnDisable() { _disable(); }
    void OnDestroy() { OnDisable(); }

    void OnEnable()
    {
        PrereqsSetup = GetComponent<EventTrigger_C>();
        _construct();
    }
    void FixedUpdate()
    {
        if (_tracker)
        {
            _time += Time.deltaTime;
            _rtime += Time.deltaTime;
        }
    }
    // all methods from Unity scripts are inherited.

    private void Start()
    {
        if (StateChanges[0] != null)
            StateChanges[0].Trigger();
        CurrentStep++;
    }

}