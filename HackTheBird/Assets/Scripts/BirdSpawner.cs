using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    [SerializeField]
    private float _originalRate = 4f;

    private float _rate;

    public Transform[] SpawnPoints;
    public Transform Enemy;

    private void Start()
    {
        _rate = _originalRate;
    }
    private void Update()
    {
        _rate -= Time.deltaTime;
        if(_rate <= 0)
        {
            Spawn();
        }
    }
    private void Spawn()
    {
        Transform SP = SpawnPoints[UnityEngine.Random.Range(0, SpawnPoints.Length)];
        Instantiate(Enemy, SP.position, Quaternion.identity);
        
        _originalRate -= 0.2f;
        if(_originalRate < 0.4)
        {
            _originalRate = 0.6f;
        }
        _rate = _originalRate;
    }
}
