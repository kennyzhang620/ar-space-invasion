using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class constraintedAxis : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform parentT;
    public bool[] Translation = { false, false, false };
    public float[] TranslationLimitsMin = { 0, 0, 0 };
    public float[] TranslationLimits = { 0, 0, 0 };
    public bool[] Rotation = { false, false, false };
    public float[] RotationLimitsMin = { 0, 0, 0 };
    public float[] RotationLimits = {0,0,0 };

    public bool[] Reset = {false, false, false,false,false,false };
    public bool db = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (db) { print(transform.localPosition); }
     //   print(transform.localPosition + "  " + transform.rotation.eulerAngles + "    _> " + RotationLimitsMin[2] + "  " + RotationLimits[2]);
        if (parentT != null)
        {
            if (Translation[0])
            {
                if (!(TranslationLimitsMin[0] <= transform.localPosition.x && transform.localPosition.x <= TranslationLimits[0]))
                    if (Reset[0])
                        transform.position = new Vector3(parentT.position.x, transform.position.y, transform.position.z);
                    else
                    {
                        if (TranslationLimitsMin[0] > transform.localPosition.x)
                            transform.localPosition = new Vector3(TranslationLimitsMin[0], transform.localPosition.y, transform.localPosition.z);
                        if (TranslationLimits[0] < transform.localPosition.x)
                            transform.localPosition = new Vector3(TranslationLimits[0], transform.localPosition.y, transform.localPosition.z);
                    }
            }
            if (Translation[1])
            {
                if (!(TranslationLimitsMin[1] <= transform.localPosition.y && transform.localPosition.y <= TranslationLimits[1]))
                    if (Reset[1])
                        transform.position = new Vector3(transform.position.x, parentT.position.y, transform.position.z);
                    else
                    {
                        if (TranslationLimitsMin[1] > transform.localPosition.y)
                            transform.localPosition = new Vector3(transform.localPosition.x, TranslationLimitsMin[1], transform.localPosition.z);
                        if (TranslationLimits[1] < transform.localPosition.y)
                            transform.localPosition = new Vector3(transform.localPosition.x, TranslationLimits[1], transform.localPosition.z);
                    }
            }
            if (Translation[2])
            {
                if (!(TranslationLimitsMin[2] <= transform.localPosition.z && transform.localPosition.z <= TranslationLimits[2]))
                    if (Reset[2])
                        transform.position = new Vector3(transform.position.x, transform.position.y, parentT.position.z);
                    else
                    {
                        if (TranslationLimitsMin[2] > transform.localPosition.z)
                            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, TranslationLimitsMin[2]);
                        if (TranslationLimits[2] < transform.localPosition.z)
                            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, TranslationLimits[2]);
                    }
            }

            if (Rotation[0])
            {
                if (!(RotationLimitsMin[0] <= transform.localRotation.eulerAngles.x && transform.localRotation.eulerAngles.x <= RotationLimits[0]))
                    if (Reset[3])
                        transform.rotation = Quaternion.Euler(parentT.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
                    else
                    {
                        if (RotationLimitsMin[0] > transform.localRotation.eulerAngles.x)
                            transform.localRotation = Quaternion.Euler(RotationLimitsMin[0], transform.localRotation.eulerAngles.y, transform.localRotation.eulerAngles.z);
                        if (RotationLimits[0] < transform.localRotation.eulerAngles.x)
                            transform.localRotation = Quaternion.Euler(RotationLimits[0], transform.localRotation.eulerAngles.y, transform.localRotation.eulerAngles.z);
                    }
            }
            if (Rotation[1])
            {
                if (!(RotationLimitsMin[1] <= transform.localRotation.eulerAngles.y && transform.localRotation.eulerAngles.y <= RotationLimits[1]))
                    if (Reset[4])
                        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, parentT.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
                    else
                    {
                        if (RotationLimitsMin[1] > transform.localRotation.eulerAngles.y)
                            transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, RotationLimitsMin[1], transform.localRotation.eulerAngles.z);
                        if (RotationLimits[1] < transform.localRotation.eulerAngles.y)
                            transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, RotationLimits[1], transform.localRotation.eulerAngles.z);
                    }
            }
            if (Rotation[2])
            {
                if (!(RotationLimitsMin[2] <= transform.localRotation.eulerAngles.z && transform.localRotation.eulerAngles.z <= RotationLimits[2]))
                    if (Reset[5])
                        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, parentT.rotation.eulerAngles.z);
                    else
                    {
                        if (RotationLimitsMin[2] > transform.localRotation.eulerAngles.z)
                            transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y, RotationLimitsMin[2]);
                        if (RotationLimits[2] < transform.localRotation.eulerAngles.z)
                            transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y, RotationLimits[2]);
                    }
            }
        }
    }
}
