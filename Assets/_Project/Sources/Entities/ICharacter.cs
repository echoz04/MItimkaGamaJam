using UnityEngine;

public interface ICharacter
{
    Transform Transform { get; }
    void UpgradeStats();
}
