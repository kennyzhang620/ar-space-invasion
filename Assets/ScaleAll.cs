using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleAll : MonoBehaviour
{
    float factor = 1;
    float clamp()
    {
        float x = Screen.width; float y = Screen.height;
        float ar = x / y;

        if (ar < 1) return 1;

        return ar + 1;
    }
    // Update is called once per frame
    void Update()
    {
        for (int i=0;i< transform.childCount;i++)
        {
            Vector3 ls = transform.GetChild(i).localScale;
            print(clamp());
            if (factor != clamp())
            {
                transform.GetChild(i).localScale = ls / factor;
                transform.GetChild(i).localScale = ls * clamp();
            }
        }

        if (factor != clamp())
        {
            factor = clamp();
        }
    }
}
