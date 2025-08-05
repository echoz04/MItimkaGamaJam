using UnityEngine;

public sealed class GunShootAbility : BaseAbility
{
    private readonly Transform _turretTransform;
    private readonly Transform _shootPoint;
    private readonly Bullet _bulletPrefab;

    public GunShootAbility(Transform turretTransform, Transform shootPoint, Bullet bulletPrefab, float cooldown)
    {
        _turretTransform = turretTransform;
        _shootPoint = shootPoint;
        _bulletPrefab = bulletPrefab;

        SetCooldown(cooldown);
    }

    public override void Execute()
    {
        GameObject.Instantiate(_bulletPrefab, _shootPoint.position, _turretTransform.rotation);
    }
}
