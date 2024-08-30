using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public TaskSupervisor[] TS; // array of pointers to DetectorManager
    List<int> completedM = new List<int>();
    public bool TrackOnly;
    public int CurrentMission = 0;

    int _initM = 0;
    bool _start = false;

    // Assign a MM to a Task Supervisor
    void _construct()
    {
        foreach (TaskSupervisor T in TS)
        {
            T.MM = this;

            if (TrackOnly && (T != null))
            {
                T.TrackOnly = TrackOnly;
            }
        }

        _initM = CurrentMission;

        LoadMission(CurrentMission);
    }

    void _disable()
    {
        foreach (TaskSupervisor T in TS)
        {
            if (T != null)
                T.enabled = false;

        }
    }

    public void LoadMission(int Index)
    {
        if (_initM != Index)
        {
            print("User skipping action! ");
            print("Expected action: " + CurrentMission + " Detected action: " + Index);
        }

        foreach (int v in TS[Index].RequiredMissions)
        {
            if (!completedM.Contains(v)) return;
        }

        if (CurrentMission == Index && _start)
        {
            return;
        }

        for (int i=0; i<TS.Length; i++) 
        {
            if (i != Index)
            {
                TS[i].enabled = false;
            }
        }

        TS[Index].enabled = true;

        _start = true;
        CurrentMission = Index;
    }
    public void StartManager()
    {
        _construct();

    }

    public void EndManager()
    {
        _disable();

    }

    // Gets the current mission
    public int GetCurrentMission()
    {
        return CurrentMission;
    }

    // Starts the next mission. Disables the existing TS.
    public void NextMission()
    {
        completedM.Add(CurrentMission);
        
        TS[CurrentMission++].enabled = false;
        TS[CurrentMission].enabled = true;
    }

    private void OnEnable()
    {
        _construct();
    }

    private void OnDisable()
    {
        _disable();
    }
}