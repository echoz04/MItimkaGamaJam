using UnityEngine;
using UnityEngine.UI;

public sealed class TurretSpawnerAbility : BaseAbility, ICooldownable
{
    private readonly TurretRoot _turretPrefab;
    private readonly ICharacter _character;

    public TurretSpawnerAbility(TurretRoot turretPrefab, ICharacter character, float cooldown)
    {
        _turretPrefab = turretPrefab;
        _character = character;

        Cooldown = cooldown;
    }

    public override void Execute()
    {
        GameObject.Instantiate(_turretPrefab, _character.Transform.position, Quaternion.identity);
    }

    public float Cooldown { get; private set; }

    private float _timeToUse;

    public override void Tick()
    {
        UpdateImage(_image);

        if (_timeToUse <= 0)
        {
            Execute();

            _timeToUse = Cooldown;
        }
        else
        {
            _timeToUse -= Time.deltaTime;
        }
    }

    private Image _image;

    public void SetImage(Image image)
    {
        _image = image;
    }

    public void UpdateImage(Image image)
    {
        _image.fillAmount = 1f - (_timeToUse / Cooldown);
    }
}
