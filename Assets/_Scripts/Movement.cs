using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _maxSpeed;

    private float _speed;
    private float _jumpForce;
    private bool _isJumping;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        _jumpForce = 600f; ;
        _speed = _maxSpeed;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isJumping == false)
        {
            _isJumping = true;
            _rigidbody2D.AddForce(Vector2.up * _jumpForce);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _speed = -_maxSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _speed = _maxSpeed;
        }
        else
        {
            _speed = 0f;
        }

        Move();

        _animator.SetBool(PlayerAnimatorData.Params.IsJumping, _isJumping);
        _animator.SetFloat(PlayerAnimatorData.Params.Speed,Mathf.Abs( _speed));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _isJumping = false;
    }

    private void Move()
    {
        transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x + _speed, transform.position.y), Time.deltaTime);
    }
}
