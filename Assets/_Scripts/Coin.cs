using UnityEngine;

public class Coin : MonoBehaviour
{
    private float _currentPositionY;
    private float _duration;
    private float _speed;

    private void OnEnable()    
    {
        _currentPositionY = transform.position.y;
        _duration = 0.2f;
        _speed = 5f;
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Sin(Time.time * _speed) * _duration + _currentPositionY, transform.position.z);

        transform.Rotate(Vector2.up, _speed);
    }
}
