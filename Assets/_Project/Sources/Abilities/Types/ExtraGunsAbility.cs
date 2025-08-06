using UnityEngine;
using UnityEngine.UI;

public sealed class ExtraGunsAbility : BaseAbility, ICooldownable
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

        Cooldown = cooldown;
    }

    public override void Execute()
    {
        AudioPlayer.Instance.PlayShootSound();

        for (int i = 0; i < _turrets.Length; i++)
            GameObject.Instantiate(_bulletPrefab, _shootPoints[i].position, _turrets[i].transform.rotation);
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
