// General Purpose detector for any player RB detection task
using System;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public int DetectorID = 0;

    public bool activated;

    [HideInInspector]
    public TaskSupervisor assignedDM;


    void OnTriggerEnter(Collider x)
    {
        // trigger conditions {
        activated = true;
        
        if (assignedDM != null)
            assignedDM.AdvanceStep(DetectorID);
    }

    void OnTriggerExit(Collider x)
    {
        // conditions {
        activated = false;
    }
// all methods from Unity scripts are inherited.

}