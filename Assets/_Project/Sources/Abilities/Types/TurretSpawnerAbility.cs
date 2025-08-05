using UnityEngine;

public sealed class TurretSpawnerAbility : BaseAbility
{
    private readonly TurretRoot _turretPrefab;
    private readonly ICharacter _character;

    public TurretSpawnerAbility(TurretRoot turretPrefab, ICharacter character, float cooldown)
    {
        _turretPrefab = turretPrefab;
        _character = character;

        SetCooldown(cooldown);
    }

    public override void Execute()
    {
        GameObject.Instantiate(_turretPrefab, _character.Transform.position, Quaternion.identity);
    }
}
