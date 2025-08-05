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

    [Header("GunShootAbility")]
    [SerializeField] private Transform _gunTransform;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _shootCooldown = 1f;
    [Space]

    [Header("FlyingSpikesAbility")]
    [SerializeField] private Transform _spikesParent;
    [SerializeField] private Spike[] _spikes;
    [SerializeField] private float _rotateSpeed;
    [Space]

    [Header("Extra Guns")]
    [SerializeField] private GameObject[] _extraGuns;
    [SerializeField] private Transform[] _shotPoints;
    [SerializeField] private float _extraShootCooldown = 1f;

    [Header("Turret Spawner")]
    [SerializeField] private TurretRoot _turretPrefab;
    [SerializeField] private float _spawnTurretsCooldown;

    private void OnValidate()
    {
        _invoker ??= GetComponent<AbilitiesInvoker>();
    }

    public void BuildGunShoot()
    {
        _invoker.Register(new GunShootAbility(_gunTransform, _shootPoint, _bulletPrefab, _shootCooldown));
    }

    private FlyingSpikesAbility _flyingSpikes;

    public void BuildFlyingSpikes()
    {
        if (_flyingSpikes == null)
            _invoker.Register(_flyingSpikes = new FlyingSpikesAbility(_spikesParent, _spikes, _rotateSpeed, 0f));
        else
            _flyingSpikes.Update();
    }

    public void BuildExtraGuns()
    {
        _invoker.Register(new ExtraGunsAbility(_extraGuns, _shotPoints, _bulletPrefab, _extraShootCooldown));
    }

    public void BuildCharacterUpgrade()
    {
        _invoker.Register(new CharacterUpgradeAbility(TankRoot.Instance));
    }

    public void BuildTurretSpawner()
    {
        _invoker.Register(new TurretSpawnerAbility(_turretPrefab, TankRoot.Instance, _spawnTurretsCooldown));
    }
}