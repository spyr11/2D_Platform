using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] GameObject _pointsPrefab;
    [SerializeField] private float _maxSpeed;

    private Transform[] _points;
    private int _currentIndex;
    
    private void Start()
    {
        _pointsPrefab = Instantiate(_pointsPrefab, transform.position, transform.rotation);
        _points = new Transform[_pointsPrefab.transform.childCount];

        for (int i = 0; i < _pointsPrefab.transform.childCount; i++)
        {
            _points[i] = _pointsPrefab.transform.GetChild(i);
        }

        _currentIndex = Random.Range(0, _points.Length);
    }

    private void Update()
    {
        MoveToPosition();
    }

    private void MoveToPosition()
    {
        Vector3 targetPosition = _points[_currentIndex].position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, _maxSpeed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            RiseIndex();
        }
    }

    private void RiseIndex()
    {
        _currentIndex++;

        if (_currentIndex >= _points.Length)
        {
            _currentIndex = 0;
        }
    }
}
