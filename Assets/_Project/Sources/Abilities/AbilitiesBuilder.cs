using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [Header("UI Setting")]
    [SerializeField] private Image _abilityIconPrefab;
    [SerializeField] private Transform _abilityIconsContent;

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

    private GunShootAbility _gunShoot;

    public void BuildGunShoot()
    {
        if (_gunShoot == null)
        {
            _invoker.Register(_gunShoot = new GunShootAbility(_gunTransform, _shootPoint, _bulletPrefab, _shootCooldown));
            Image instance = Instantiate(_abilityIconPrefab, _abilityIconsContent);
            _gunShoot.SetImage(instance);
        }
    }

    private FlyingSpikesAbility _flyingSpikes;

    public void BuildFlyingSpikes()
    {
        if (_flyingSpikes == null)
            _invoker.Register(_flyingSpikes = new FlyingSpikesAbility(_spikesParent, _spikes, _rotateSpeed));
        else
            _flyingSpikes.Update();
    }

    private ExtraGunsAbility _extrasGuns;

    public void BuildExtraGuns()
    {
        if (_extrasGuns == null)
        {
            _invoker.Register(_extrasGuns = new ExtraGunsAbility(_extraGuns, _shotPoints, _bulletPrefab, _extraShootCooldown));
            Image instance = Instantiate(_abilityIconPrefab, _abilityIconsContent);
            _extrasGuns.SetImage(instance);
        }
    }

    public void BuildCharacterUpgrade()
    {
        _invoker.Register(new CharacterUpgradeAbility(TankRoot.Instance));
    }

    private TurretSpawnerAbility _turretSpawner;

    public void BuildTurretSpawner()
    {
        if (_extrasGuns == null)
        {
            _invoker.Register(_turretSpawner = new TurretSpawnerAbility(_turretPrefab, TankRoot.Instance, _spawnTurretsCooldown));
            Image instance = Instantiate(_abilityIconPrefab, _abilityIconsContent);
            _turretSpawner.SetImage(instance);
        }
    }
}