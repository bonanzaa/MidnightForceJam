using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    
    private float _lerpTime = 1f;
    private float _currentLerpTime;
    private float _moveDistance;

    private Vector2 _startPos;
    private Vector2 _endPos;
    private void Start()
    {
        //_startPos
    }
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * _speed, Space.World);
    }
}
