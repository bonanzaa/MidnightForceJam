using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private Vector2 _input;
    private float _slowedDownDuration = 5f;
    private PigeonHealth _pidgeonlHealth;

    private void Start()
    {
        _pidgeonlHealth = GetComponent<PigeonHealth>();
    }
    private void Update()
    {
        HandleInput();
        Move();
    }
    private void HandleInput()
    {
        float moveY = 0f;
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            moveY += 1f;
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            moveY -= 1f;
        }
        else
        {
            _input = new Vector2(0, 0);
        }
        _input = new Vector2(0, moveY).normalized;

    }
    private void Move()
    {
        if (_input.y > 0 && transform.position.y < 3f)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 3f);
        }
        else if (_input.y < 0 && transform.position.y > -3f)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 3f);
        }
        else
        {
            transform.position = transform.position;
        }
        transform.Translate(Vector2.right * Time.deltaTime * _speed, Space.World);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Slow"))
        {
            Debug.Log("hit something");
            _speed -= 2f;
            new WaitForSeconds(_slowedDownDuration);
            Debug.Log(_speed);
            _pidgeonlHealth.TakeDamage();
            //StartCoroutine(SlowedDown(_slowedDownDuration));
            //_speed += 2f;
        }
        _speed += 2f;
    }
    //private IEnumerator SlowedDown(float time)
    //{
    //    while(true)
    //    {
    //        _speed -= 2f;
    //        yield return new WaitForSeconds(time);
    //    }
    //}
}
