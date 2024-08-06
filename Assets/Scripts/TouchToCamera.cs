using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchToCamera : MonoBehaviour
{
    public CameraAnimator cameraAnimator;
    public float modVar = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void DragUpdate()
    {
        cameraAnimator.ay = modVar*Input.GetAxis("Mouse Y");

        if (Mathf.Abs(cameraAnimator.ay) < 0.000001f) {
            cameraAnimator.Stop();
        }
    }

    public void StopUpdate() {
        cameraAnimator.ay = 0;
    }
}
