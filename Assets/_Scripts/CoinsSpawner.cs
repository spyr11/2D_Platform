
using UnityEngine;

public class CoinsSpawner : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _mapBounds;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private uint _count;

    private void Start()
    {
        float mapSizeX = _mapBounds.bounds.max.x - _mapBounds.bounds.min.x;
        float offset = mapSizeX / _count;

        float positionX = _mapBounds.bounds.min.x;
        float positionY = transform.position.y;

        for (uint i = 0; i < _count; i++)
        {
            var position = new Vector3(positionX, positionY, 0);

            Instantiate(_prefab, position, Quaternion.identity);

            positionX += offset;
        }
    }
}
