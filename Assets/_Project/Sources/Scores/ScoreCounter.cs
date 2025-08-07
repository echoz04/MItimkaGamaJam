using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _worldCanvas;
    [SerializeField] private ScorePopup _popupPrefab;

    private int _score;

    private void Awake()
    {
        Instance = this;

        _score = 0;
        _text.text = _score.ToString();
    }

    public void Add(int score, Transform spawnPosition)
    {
        _score += score;

        _text.text = _score.ToString();
        _animator.enabled = true;

        var popup = Instantiate(_popupPrefab, spawnPosition.position, Quaternion.identity, _worldCanvas);

        popup.Initialize(score);
    }

    public int GetScore() => _score;

    public void DisableAnimator() => _animator.enabled = false;
}
