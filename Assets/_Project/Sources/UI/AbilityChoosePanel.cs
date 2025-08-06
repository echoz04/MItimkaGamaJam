using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class AbilityChoosePanel : MonoBehaviour
{
    public static AbilityChoosePanel Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI[] _abilitiesDisplayTexts;

    private List<AbilityInfo> _abilitiesInfo;

    private List<AbilityInfo> _currentAbilitiesInfo;

    public void Initialize()
    {
        Instance = this;

        _abilitiesInfo = new List<AbilityInfo>()
        {
            new AbilityInfo { Title = "Flying Spikes", BuildAction = AbilitiesBuilder.Instance.BuildFlyingSpikes },
            new AbilityInfo { Title = "Extra Guns", BuildAction = AbilitiesBuilder.Instance.BuildExtraGuns },
            new AbilityInfo { Title = "Upgrade Stats", BuildAction = AbilitiesBuilder.Instance.BuildCharacterUpgrade },
            new AbilityInfo { Title = "Turrets", BuildAction = AbilitiesBuilder.Instance.BuildTurretSpawner },
        };

        gameObject.SetActive(false);
    }

    public void Show()
    {
        Time.timeScale = 0;

        gameObject.SetActive(true);

        _currentAbilitiesInfo = _abilitiesInfo
            .OrderBy(x => Random.value)
            .Take(3)
            .ToList();

        for (int i = 0; i < _currentAbilitiesInfo.Count && i < _abilitiesDisplayTexts.Length; i++)
            _abilitiesDisplayTexts[i].text = _currentAbilitiesInfo[i].Title;
    }

    public void ChooseAbility(int index)
    {
        if (index < 0 || index >= _currentAbilitiesInfo.Count) return;

        _currentAbilitiesInfo[index].BuildAction?.Invoke();

        gameObject.SetActive(false);

        Time.timeScale = 1;
    }
}

[System.Serializable]
public class AbilityInfo
{
    public string Title;
    public System.Action BuildAction;
}
