using TMPro;
using UnityEngine;

public class ScorePopup : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _moveDistance = 1f;
    [SerializeField] private float _duration = 1f;

    private Vector3 _startPosition;
    private Vector3 _endPosition;

    public void Initialize(int score)
    {
        _text.text = score.ToString();

        _startPosition = transform.position;
        _endPosition = _startPosition + Vector3.up * _moveDistance;

        StartCoroutine(MoveAndFade());
    }

    private System.Collections.IEnumerator MoveAndFade()
    {
        float elapsed = 0f;

        while (elapsed < _duration)
        {
            float t = elapsed / _duration;
            transform.position = Vector3.Lerp(_startPosition, _endPosition, t);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = _endPosition;

        Destroy(gameObject);
    }
}