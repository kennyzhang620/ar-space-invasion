using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zappar;

public class BeeManipulationScript : MonoBehaviour
{
    public bool Controller = false; // True if the current GameObject is an controller. Will send commands to Bee GameObjects
    public ZapparInstantTrackingTarget ARTarget;

    Transform BeeTarget;
    public GameObject ARBase;
    public bool Tutorial = false;

    Touch in1, in2;
    float currDist = 0;

    public float currVelocityX = 0; // In units per second
    public float currVelocityY = 0; // In units per second
    public float currScale = 1;
    public float Tick = 0; // 1 tick = 1 ms


    public Vector3 LockVector = Vector3.one; // Default state has no lock
    public bool Scale = true;
    float maxTick = 2;

    public Vector3 mousePosition;
    RaycastHit ray;
    // Start is called before the first frame update
    void Start()
    {
        GameObject ARObj = GameObject.Find("ZapparARTracker");

        if (ARObj != null)
            ARTarget = ARObj.GetComponent<ZapparInstantTrackingTarget>();
    }

    void ManipulateBee(Vector3 pos)
    {
        if (ARTarget == null)
        {
            if (pos != Vector3.zero)
            {
                currVelocityX += -pos.x;
                currVelocityY += pos.y;
            }
            else
            {
                currVelocityX = 0;
                currVelocityY = 0;

            }
        }
    }

    void ZoomBee(float Scale)
    {
        if (ARTarget == null)
        {
            gameObject.transform.localScale = new Vector3(Scale, Scale, Scale);
        }
    }


    void ReloadBase()
    {
        if (!Tutorial)
        {
            if (ARBase != null)
                ARBase.SetActive(true);

            gameObject.transform.localScale = new Vector3(1, 1, 1);
            gameObject.transform.localRotation = Quaternion.Euler(Vector3.zero);
            currVelocityX = 0;
            currVelocityY = 0;
        }
    }

    void ModifyTick(float tick)
    {
        Tick = tick;
    }

    public void Move()
    {
        if (((Input.GetMouseButton(0) && Input.touchCount == 0)) || (Input.GetMouseButton(0) && (Input.touchCount == 1)))
        {
            float modVar = 0.4f;

            if ((Input.GetMouseButton(0) && Input.touchCount == 0))
                modVar *= 10;

            mousePosition.x = modVar*Input.GetAxis("Mouse X");
            mousePosition.y = modVar*Input.GetAxis("Mouse Y");

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out ray))
            {

                if (ray.transform.gameObject.tag == "Bee")
                {
                    if (BeeTarget != null && (ARTarget != null))
                        BeeTarget.SendMessage("ModifyTick", -1200);

                    mousePosition.x *= LockVector.x;
                    mousePosition.y *= LockVector.y;
                    mousePosition.z *= LockVector.z;
                    
                    ray.transform.SendMessage("ManipulateBee", mousePosition);

                    BeeTarget = ray.transform; // Update the transform
                }
            }
        }

        
    }

    void OnTick()
    {
 
    }

    IEnumerator DelayedControl()
    {
        while (true)
        {
            OnTick();

            yield return null;
        }
       
    }
    // Update is called once per frame
    void OnEnable()
    {
        if (!Controller)
        {
          //  StartCoroutine(DelayedControl());
            
        }
        else
        {
            Move();
        }
    }

    void FixedUpdate()
    {
        if (!Controller)
        {
            OnTick();
        }
        else
        {
            Move();
        }
    }

    void OnDestroy()
    {
     //   StopCoroutine(DelayedControl());
    }
}
