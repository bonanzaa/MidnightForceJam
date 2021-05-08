using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    
    private void Start()
    {

    }
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * _speed, Space.World);        
    }
    
}
