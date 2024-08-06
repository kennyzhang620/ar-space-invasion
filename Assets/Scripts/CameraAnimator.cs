using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimator : MonoBehaviour
{
    float dx = 0;
    float dy = 0;
    float dz = 0;

    public float damper = 1;
    public float ax =0;
    public float ay =0;
    public float az =0;

    public Vector3 anchor;
    public float maxRadius = 2;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void DisableAnim() {
        anim.enabled = false;
    }

    public void Stop() {
        dx = 0;
        dy = 0;
        dz = 0;
    }

    float computeDistance() {
        return (transform.position + new Vector3(dx, dy, dz)).magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        dx += ax;
        dy += ay;
        dz += az;

        if (ax+ay+az == 0) {
            if (dx > 0) {
                dx -= damper;

                if (dx < 0)
                    dx = 0;
            }

            if (dx < 0) {
                dx += damper;

                if (dx > 0)
                    dx = 0;
            }

            
            if (dy > 0) {
                dy -= damper;

                if (dy < 0)
                    dy = 0;
            }

            if (dy < 0) {
                dy += damper;

                if (dy > 0)
                    dy = 0;
            }

            if (dz > 0) {
                dz -= damper;

                if (dz < 0)
                    dz = 0;
            }

            if (dz < 0) {
                dz += damper;

                if (dz > 0)
                    dz = 0;
            }
        }
print(computeDistance());
        if (computeDistance() > maxRadius) {
            dx = 0; dy = 0; dz = 0;
            return;
        }

        transform.Translate(dx,dy,dz);
        
    }
}
