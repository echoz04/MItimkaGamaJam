using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float MovementSpeed = 10.0f;
    public float MovementAcceleration = 10.0f;

    private Transform targetTransform;

    private Rigidbody2D rigidbody; 
    private Transform selfTransform;

    void Start()
    {
        targetTransform = EnemiesController.EnemiesTargetTransform;
        selfTransform = GetComponent<Transform>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 directionToTarget = (Vector2)((Vector2)targetTransform.position - (Vector2)selfTransform.position).normalized;
        rigidbody.linearVelocity = Vector2.Lerp(rigidbody.linearVelocity, directionToTarget * MovementSpeed, Time.deltaTime * MovementAcceleration);
    }
}
