using UnityEngine;

public interface IAbility
{
    float Cooldown { get; }
    void Tick();
    void Execute();
}
