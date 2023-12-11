using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _blowPrefab;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            Instantiate(_blowPrefab, transform.position, transform.rotation);

            Destroy(gameObject);
        }

        if (other.TryGetComponent<Coin>(out Coin coin))
        {
            Destroy(coin.gameObject);
        }
    }
}
