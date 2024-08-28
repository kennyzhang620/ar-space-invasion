using System.Collections;
using System.Collections.Generic;
using Autohand;
using UnityEngine;
using TMPro;

public class FakeEnemy : Enemy
{
    public TextMeshPro Dt;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    public void OnShot(AutoGun G, RaycastHit R)
    {
        var dp = G.gameObject.GetComponent<DamageParameters>();

        Dt.text = G.gameObject.ToString();
        if (dp != null)
        {
            // Perform damage calculation

            int dmg = dp.Damage * dp.ArmourPenetrate;

            int v = Armour - dmg;

            if (v < 0)
                Health += v;
            else
                Armour -= dmg;

        }
    }
}
