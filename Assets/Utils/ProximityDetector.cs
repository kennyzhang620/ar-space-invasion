using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityDetector : Detector
{
    public Camera cam;
    public Transform origin;
    public Transform target;

    public float minDist = 1.0f;

    bool isLookingAt(Transform target)
    {
        Vector3 viewPos = cam.WorldToViewportPoint(target.position);
     //   print(viewPos);
        if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)
        {
            // Your object is in the range of the camera, you can apply your behaviour
            return true;
        }

        return false;   
    }
    bool closeEnough()
    {
       // print((target.position - origin.position).magnitude / target.position.magnitude);
        return ((target.position - origin.position).magnitude / target.position.magnitude <= minDist);
    }

    private void OnTriggerEnter(Collider x)
    {
    }

    private void OnTriggerStay(Collider other)
    {
     //   print("---> " + (closeEnough() && isLookingAt(origin)).ToString());
        if (closeEnough() && isLookingAt(origin))
        {
            print("on");
            assignedDM.AdvanceStep(DetectorID);
            activated = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
    }
}
