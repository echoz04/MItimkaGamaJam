using UnityEngine;

public class TurretRoot : MonoBehaviour
{
    [SerializeField] private float _lifeTime;
    [SerializeField] private float _fireRate = 1f;
    [SerializeField] private float _range = 10f;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePoint;

    private float _fireTimer;

    private void Start()
    {
        Invoke(nameof(Kill), _lifeTime);
    }

    private void Update()
    {
        var nearestEnemy = FindNearestEnemy();
        if (nearestEnemy == null)
            return;

        Vector2 direction = (nearestEnemy.transform.position - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        _fireTimer += Time.deltaTime;
        if (_fireTimer >= _fireRate)
        {
            Shoot(angle);
            _fireTimer = 0f;
        }
    }

    private Enemy FindNearestEnemy()
    {
        Enemy[] enemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None);
        Enemy nearest = null;
        float minDistance = Mathf.Infinity;

        foreach (var enemy in enemies)
        {
            float dist = Vector2.Distance(transform.position, enemy.transform.position);

            if (dist < minDistance && dist <= _range)
            {
                minDistance = dist;
                nearest = enemy;
            }
        }

        return nearest;
    }

    private void Shoot(float angle)
    {
        if (_bulletPrefab == null || _firePoint == null)
            return;

        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        Instantiate(_bulletPrefab, _firePoint.position, rotation);
    }

    private void Kill() =>
        Destroy(gameObject);
}