using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Enemy[] Enemies;
    public bool AnyColour = true;
    public int MaxSpawn = 100;
    public float Range = 15;

    public float TimeInterval = 2;

    float _t = 0;
    List<Enemy> _spawned = new List<Enemy>();

    // Start is called before the first frame update
    void Start()
    {
        if (Enemies.Length <= 0) Debug.LogError("No enemies!");

        return;
    }

    // Update is called once per frame
    void Update()
    {
        if (_spawned.Count > MaxSpawn) return;
        _t += Time.deltaTime;
        
        if (_t < TimeInterval) return;

        float sv = Random.Range(0, 1);
        float rv = (sv - 0.5f) * Range;
        Vector3 rand = new Vector3(rv, 0*rv, 0*rv);

        foreach (Enemy e in Enemies)
        {
            if (sv < e.SpawnRate)
            {
                Enemy res = Instantiate(e, transform.position + rand, Quaternion.identity);
                res.Identifier = Enemies.Length - 1;
                res.source = this;
                if (!res) return;

                _spawned.Add(res);
            }
        }

        _t = 0;
    }

    public void Destroyed(int id)
    {
        _spawned.RemoveAt(id);
    }
    public void ResetSpawner()
    {
        foreach (Enemy e in _spawned)
        {
            Destroy(e.gameObject);
            _spawned.RemoveAt(e.Identifier);
        }
    }
}

