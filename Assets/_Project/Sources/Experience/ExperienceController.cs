using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExperienceController : MonoBehaviour
{
    public static ExperienceController Insntance { get; private set; }

    [SerializeField] private List<LevelInfo> _levelInfos = new();
    [SerializeField] private TextMeshProUGUI _display;

    private int _currentExperience;
    private int _currentLevel;

    private void Awake()
    {
        Insntance = this;

        _currentLevel = 0;
        _display.text = $"{_currentExperience}/{_levelInfos[_currentLevel].NeedExperienceToNextLevel}";
    }

    public void GiveExperience(int value)
    {
        Debug.Log($"OnGiveExperience _levelInfos.Count is {_levelInfos.Count} and _currentLevel is {_currentLevel}");

        if (_levelInfos.Count < _currentLevel)
        {
            _display.text = $"Max Level";

            return;
        }

        _currentExperience += value;

        _display.text = $"{_currentExperience}/{_levelInfos[_currentLevel].NeedExperienceToNextLevel}";

        if (_currentExperience >= _levelInfos[_currentLevel].NeedExperienceToNextLevel)
        {
            SetNextLevel();
        }
    }

    private void SetNextLevel()
    {
        _currentLevel++;

        AbilityChoosePanel.Instance.Show();

        _currentExperience = 0;
    }
}

[System.Serializable]
public class LevelInfo
{
    public int NeedExperienceToNextLevel;
}
