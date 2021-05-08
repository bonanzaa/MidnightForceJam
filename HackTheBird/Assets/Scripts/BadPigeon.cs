using UnityEngine;

public class BadPigeon : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime, Space.World);
    }
}
