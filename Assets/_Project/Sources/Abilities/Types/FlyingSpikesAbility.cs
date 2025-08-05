using UnityEngine;

public sealed class FlyingSpikesAbility : BaseAbility, IUpdateable
{
    private readonly Transform _spikesParent;
    private readonly float _rotateSpeed;
    private readonly Spike[] _spikes;

    private int _currenSpikeIndex;

    public FlyingSpikesAbility(Transform spikesParent, Spike[] spikes, float rotateSpeed, float cooldown)
    {
        _spikesParent = spikesParent;
        _rotateSpeed = rotateSpeed;
        _spikes = spikes;
        _currenSpikeIndex = 0;

        Update();

        _spikesParent.gameObject.SetActive(true);

        SetCooldown(cooldown);
    }

    public override void Execute()
    {
        _spikesParent.Rotate(0f, 0f, _rotateSpeed * Time.deltaTime);
    }

    public void Update()
    {
        if (_spikes.Length > _currenSpikeIndex)
        {
            _spikes[_currenSpikeIndex].gameObject.SetActive(true);
            _currenSpikeIndex++;
        }
    }
}
