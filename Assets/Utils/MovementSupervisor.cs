using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSupervisor : TaskSupervisor
{
    /*
     * public EventTrigger_C[] StateChanges;
    public Detector[] Detectors;
    public MissionManager MM;

    [HideInInspector]
    public int CurrentStep = 0;
    [HideInInspector]
    public bool _missionComplete = false;
     * */

    private void Start()
    {
        StateChanges[0].Trigger();
        CurrentStep++;

        StartTimer();
    }

    public override void AdvanceStep(int id)
    {

        if (!enabled)
        {
            return;
        }
        // condition for passing {

        if (id == CurrentStep)
        {
            StateChanges[id].Trigger();
            CurrentStep++;
            CaptureTimestamp();
        }

        if (CurrentStep >= StateChanges.Length)
        {
            _missionComplete = true;
            StopTimer();
            PrintTimestamps();
            MM.NextMission();
        }

    }
}
