using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zappar;

public class BasicShipAI : MonoBehaviour
{
    public ZapparInstantTrackingTarget_EXT ZT;
    public float speed = 0.01f;
    public int Damage = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ZT.m_minZDistance > 0)
        {
            ZT.m_minZDistance -= speed;
            ZT.m_maxZDistance -= speed;
        }
        else {
            GameSettings.Health -= Damage;
            Destroy(this);
        }
    }
}
