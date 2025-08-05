using UnityEngine;

public sealed class ExtraGunsAbility : BaseAbility
{
    private readonly GameObject[] _turrets;
    private readonly Transform[] _shootPoints;
    private readonly Bullet _bulletPrefab;

    public ExtraGunsAbility(GameObject[] turrets, Transform[] shootPoints, Bullet bulletPrefab, float cooldown)
    {
        _turrets = turrets;
        _shootPoints = shootPoints;
        _bulletPrefab = bulletPrefab;

        foreach (var turret in _turrets)
            turret.SetActive(true);

        SetCooldown(cooldown);
    }

    public override void Execute()
    {
        for (int i = 0; i < _turrets.Length; i++)
            GameObject.Instantiate(_bulletPrefab, _shootPoints[i].position, _turrets[i].transform.rotation);
    }
}
