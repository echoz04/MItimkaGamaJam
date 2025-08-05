using UnityEngine;

public class BaseAbility : IAbility
{
    public float Cooldown { get; private set; }

    private float _timeToUse;

    public void Tick()
    {
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

    public virtual void Execute() { }

    protected void SetCooldown(float newColdown) => Cooldown = newColdown;
}
