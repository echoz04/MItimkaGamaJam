using UnityEngine;

public sealed class FlyingSpikesAbility : BaseAbility
{
    private readonly Transform _spikesParent;
    private readonly float _rotateSpeed;

    public FlyingSpikesAbility(Transform spikesParent, float rotateSpeed, float cooldown)
    {
        _spikesParent = spikesParent;
        _rotateSpeed = rotateSpeed;

        _spikesParent.gameObject.SetActive(true);

        SetCooldown(cooldown);
    }

    public override void Execute()
    {
        _spikesParent.Rotate(0f, 0f, _rotateSpeed * Time.deltaTime);
    }
}
