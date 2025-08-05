using System.Collections.Generic;
using UnityEngine;

public class AbilitiesInvoker : MonoBehaviour
{
    private List<IAbility> _abilities = new();

    private void Update()
    {
        for (int i = 0; i < _abilities.Count; i++)
            _abilities[i].Tick();
    }

    public void Register(IAbility ability)
    {
        if (_abilities.Contains(ability) == true || ability == null)
            return;

        _abilities.Add(ability);
    }

    public void Unregister(IAbility ability)
    {
        if (_abilities.Contains(ability) == false || ability == null)
            return;

        _abilities.Remove(ability);
    }
}