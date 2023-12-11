using UnityEngine;

class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private BoxCollider2D _mapBounds;

    private Vector3 _newPosition;
    private float _minBoundX;
    private float _maxBoundX;

    private void Start()
    {
        _minBoundX = _mapBounds.bounds.min.x + Camera.main.orthographicSize;
        _maxBoundX = _mapBounds.bounds.max.x - Camera.main.orthographicSize;
    }

    private void LateUpdate()
    {
        if (_target != null)
        {
            _newPosition = transform.position;
            _newPosition.x = Mathf.Clamp(_target.position.x, _minBoundX, _maxBoundX);
        }

        _minBoundX = Mathf.Clamp(_minBoundX, _newPosition.x, _maxBoundX);
        transform.position = _newPosition;
    }
}