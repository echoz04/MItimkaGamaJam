using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public static AudioPlayer Instance { get; private set; }

    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _enemyHitSound;
    [SerializeField] private AudioClip _enemyDeadSound;
    [SerializeField] private AudioClip _shootSound;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayEnemyHitSound() => _source.PlayOneShot(_enemyHitSound);

    public void PlayEnemyDeadSound() => _source.PlayOneShot(_enemyDeadSound);

    public void PlayShootSound() => _source.PlayOneShot(_shootSound);
}
