using UnityEngine;

public interface ICharacter
{
    Transform Transform { get; }
    bool IsMoving { get; }
    void UpgradeStats();
}
