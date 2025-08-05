using System.Collections.Generic;
using UnityEngine;

public class AbilitiesBuilder : MonoBehaviour
{
    public static AbilitiesBuilder Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField] private AbilitiesInvoker _invoker;
    [Space]

    [SerializeField] private Transform _turretTransform;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _shootCooldown = 1f;
    [Space]

    [SerializeField] private Transform _spikesParent;
    [SerializeField] private float _rotateSpeed;

    private void OnValidate()
    {
        _invoker ??= GetComponent<AbilitiesInvoker>();
    }

    public void BuildTurretShoot()
    {
        _invoker.Register(new TurretShootAbility(_turretTransform, _shootPoint, _bulletPrefab, _shootCooldown));
    }

    public void BuildFlyingSpikes()
    {
        _invoker.Register(new FlyingSpikesAbility(_spikesParent, _rotateSpeed, 0f));
    }
}