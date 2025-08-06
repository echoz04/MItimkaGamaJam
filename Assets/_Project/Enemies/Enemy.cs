using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _giveExperience;
    [SerializeField] private ParticleSystem _hitParticle;
    [SerializeField] private ParticleSystem _deadParticle;

    public float MovementSpeed = 10.0f;
    public float MovementAcceleration = 10.0f;

    private Transform targetTransform;

    private Rigidbody2D rigidbody;
    private Transform selfTransform;

    private HealthComponent healthComponent;

    public event Action OnDestroyed;

    bool isDestroyed = false;

    void Start()
    {
        targetTransform = EnemiesController.EnemiesTargetTransform;
        selfTransform = GetComponent<Transform>();
        rigidbody = GetComponent<Rigidbody2D>();

        healthComponent = GetComponent<HealthComponent>();
        healthComponent.OnHealthEnded += () =>
        {
            AudioPlayer.Instance.PlayEnemyDeadSound();
            _deadParticle.Play();
            OnDestroyed?.Invoke();
            isDestroyed = true;
            Destroy(gameObject, .35f);
        };

        healthComponent.OnHealthChanged += (delta) =>
        {
            AudioPlayer.Instance.PlayEnemyHitSound();
            ExperienceController.Insntance.GiveExperience(_giveExperience);
            _hitParticle.Play();

            if (delta > 0)
            {
                rigidbody.linearVelocity = new Vector2(0, 0);
                rigidbody.angularVelocity = 0.0f;
            }
        };
    }

    void FixedUpdate()
    {
        Vector2 directionToTarget = (Vector2)((Vector2)targetTransform.position - (Vector2)selfTransform.position).normalized;
        Vector2 targetVelocity = directionToTarget * MovementSpeed;
        if (isDestroyed)
        {
            targetVelocity = new Vector2();
        }

        rigidbody.angularVelocity = Mathf.Lerp(rigidbody.angularVelocity, 0.0f, Time.deltaTime * MovementAcceleration * .5f);
        rigidbody.linearVelocity = Vector2.Lerp(rigidbody.linearVelocity, targetVelocity, Time.deltaTime * MovementAcceleration);
    }
}
