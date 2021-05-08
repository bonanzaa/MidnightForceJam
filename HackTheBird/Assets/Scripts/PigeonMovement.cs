using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private Vector2 _input;

    private PigeonHealth _pidgeonlHealth;
    private CapsuleCollider2D _collider;

    private void Start()
    {
        _pidgeonlHealth = GetComponent<PigeonHealth>();
        _collider = GetComponent<CapsuleCollider2D>();
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
        if (collision.CompareTag("PowerUp"))
        {
            Destroy(collision.gameObject);
            StartCoroutine(Invincibility(1f));
        }
        else if (collision.CompareTag("Enemy") && _collider.enabled)
        {
            Destroy(collision.gameObject);
            _pidgeonlHealth.TakeDamage();
        }
        else if (collision.CompareTag("Towers") && _pidgeonlHealth._canTakeDamage)
        {
            _pidgeonlHealth.TakeDamage();
        }
    }
    private IEnumerator Invincibility(float duration)
    {
        while (duration > 0)
        {
            yield return null;
            _pidgeonlHealth._canTakeDamage = false;
            duration -= Time.deltaTime;
            //Glow for shield or whatever the fucking fuck I hate Maduro
        }
        _pidgeonlHealth._canTakeDamage = true;
    }
}
