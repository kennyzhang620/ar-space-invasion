using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int Health = 10;
    public int Armour = 0;

    public void SetDamage(int d)
    {
        int v = Armour - d;

        if (v < 0)
            Health += v;
        else
            Armour -= d;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
