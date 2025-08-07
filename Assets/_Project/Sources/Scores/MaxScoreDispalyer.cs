using TMPro;
using UnityEngine;

public class MaxScoreDisplayer : MonoBehaviour
{
    public static MaxScoreDisplayer Instance { get; private set; }

    public int MaxScore;

    [SerializeField] private TextMeshProUGUI _text;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        if (MaxScore > 0)
            Display();
        else
            _text.text = "";
    }

    public void Display()
    {
        if (MaxScore > 0)
            _text.text = "max score: " + MaxScore;
        else
            _text.text = "";
    }

    public void SetMaxScore(int score)
    {
        if (score > MaxScore)
            MaxScore = score;
    }
}
