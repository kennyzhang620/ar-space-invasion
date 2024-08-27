using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string PlayerName;
    public int Health = 1;
    public int Damage = 1;
    public float hitDistance = 0.5f;
    public float Speed = 0.5f;
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
            Destroy(gameObject);
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
    }
}
