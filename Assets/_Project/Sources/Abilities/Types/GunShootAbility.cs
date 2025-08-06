using UnityEngine;
using UnityEngine.UI;

public sealed class GunShootAbility : BaseAbility, ICooldownable
{
    private readonly Transform _turretTransform;
    private readonly Transform _shootPoint;
    private readonly Bullet _bulletPrefab;

    public GunShootAbility(Transform turretTransform, Transform shootPoint, Bullet bulletPrefab, float cooldown)
    {
        _turretTransform = turretTransform;
        _shootPoint = shootPoint;
        _bulletPrefab = bulletPrefab;

        Cooldown = cooldown;
    }

    public override void Execute()
    {
        AudioPlayer.Instance.PlayShootSound();

        GameObject.Instantiate(_bulletPrefab, _shootPoint.position, _turretTransform.rotation);

        Debug.Log("Execute");
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
        if (_image == null)
            return;

        _image.fillAmount = 1f - (_timeToUse / Cooldown);
    }
}
