using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceController : MonoBehaviour
{
    public static ExperienceController Insntance { get; private set; }

    [SerializeField] private List<LevelInfo> _levelInfos = new();
    // [SerializeField] private TextMeshProUGUI _display;
    [SerializeField] private Slider _slider;

    [SerializeField] private int _currentExperience;
    [SerializeField] private int _currentLevel;

    private void Awake()
    {
        Insntance = this;

        _currentLevel = 0;
        // _display.text = $"{_currentExperience}/{_levelInfos[_currentLevel].NeedExperienceToNextLevel}";
        _slider.value = _currentExperience;
        _slider.maxValue = GetTargetToNextLevelExperience();
    }

    public void GiveExperience(int value)
    {
        Debug.Log($"OnGiveExperience _levelInfos.Count is {_levelInfos.Count} and _currentLevel is {_currentLevel}");

        if (_levelInfos.Count < _currentLevel)
        {
            // _display.text = $"Max Level";
            _slider.value = 1.0f;

            return;
        }

        _currentExperience += value;

        // _display.text = $"{_currentExperience}/{_levelInfos[_currentLevel].NeedExperienceToNextLevel}";
        _slider.value = _currentExperience;

        if (_currentExperience >= GetTargetToNextLevelExperience())
        {
            SetNextLevel();
        }
    }

    private void SetNextLevel()
    {
        _slider.maxValue = GetTargetToNextLevelExperience();

        _currentLevel++;

        AbilityChoosePanel.Instance.Show();

        _currentExperience = 0;
        _slider.value = _currentExperience;
    }

    public int GetTargetToNextLevelExperience()
    {
        return _levelInfos[_currentLevel].NeedExperienceToNextLevel;
        //return Mathf.Max(1, _currentLevel * 20) * (_currentLevel > 2 ? _currentLevel / 2 : 1);
    }
}

[System.Serializable]
public class LevelInfo
{
    public int NeedExperienceToNextLevel;
}
