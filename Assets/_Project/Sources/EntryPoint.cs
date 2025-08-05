using System.Collections.Generic;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private AbilityChoosePanel _abilityChoosePanel;

    private void Start()
    {
        _abilityChoosePanel.Initialize();

        AbilityChoosePanel.Instance.Show();
    }
}