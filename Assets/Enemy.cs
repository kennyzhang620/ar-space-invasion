using System.Collections;
using System.Collections.Generic;
using Autohand;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string PlayerName;
    public int Identifier;
    public int Health = 1;
    public int Armour = 0;
    public int Damage = 1;
    public float hitDistance = 0.5f;
    public float Speed = 0.5f;
    public float SpawnRate = 0.25f;

    public Spawner source;
    Transform _player;

    
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find(PlayerName).transform;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == PlayerName)
        {
            PlayerHealth v = collision.gameObject.GetComponent<PlayerHealth>();
            v.SetDamage(Damage);

            source.Destroyed(Identifier);
            Destroy(gameObject);
        }
    }

    public void OnShot(AutoGun G, RaycastHit R)
    {
        var dp = R.collider.gameObject.GetComponent<DamageParameters>();

        if (dp != null)
        {
            // Perform damage calculation

            int dmg = dp.Damage*dp.ArmourPenetrate;

            int v = Armour - dmg;

            if (v < 0)
                Health += v;
            else
                Armour -= dmg;

        }
    }
    // Update is called once per frame
    void Update()
    {
        if ((transform.position - _player.position).magnitude > hitDistance)
        {
            transform.LookAt(_player.position, Vector3.up);
            transform.Translate(Vector3.forward*Speed);
        }

        if (Health <= 0)
        {
            source.Destroyed(Identifier);
            Destroy(gameObject);
        }
    }
}
