using UnityEngine;

public sealed class CharacterUpgradeAbility : BaseAbility
{
    public CharacterUpgradeAbility(ICharacter character)
    {
        character.UpgradeStats();
    }
}
