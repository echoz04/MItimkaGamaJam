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
        GameObject nearestEnemy = FindNearestEnemy();
        if (nearestEnemy == null)
            return;

        Vector3 direction = (nearestEnemy.transform.position - transform.position).normalized;

        // Optional: rotate turret to face target (2D)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        _fireTimer += Time.deltaTime;
        if (_fireTimer >= _fireRate)
        {
            Shoot(direction);
            _fireTimer = 0f;
        }
    }

    private GameObject FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearest = null;
        float minDistance = Mathf.Infinity;

        foreach (var enemy in enemies)
        {
            float dist = Vector3.Distance(transform.position, enemy.transform.position);
            if (dist < minDistance && dist <= _range)
            {
                minDistance = dist;
                nearest = enemy;
            }
        }

        return nearest;
    }

    private void Shoot(Vector3 direction)
    {
        if (_bulletPrefab == null || _firePoint == null)
            return;

        GameObject bullet = Instantiate(_bulletPrefab, _firePoint.position, Quaternion.identity);
        bullet.GetComponent<Bullet>()?.Initialize(direction);
    }

    private void Kill() =>
        Destroy(gameObject);
}
