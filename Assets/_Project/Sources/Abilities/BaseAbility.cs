using UnityEngine;

public class BaseAbility : IAbility
{
    public virtual void Tick() { }

    public virtual void Execute() { }
}
