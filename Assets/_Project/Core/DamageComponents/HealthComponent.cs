using UnityEngine;
using System;

public class HealthComponent : MonoBehaviour
{
    public float MaxHealth = 100.0f;
    public float Health;

    public event Action<float> OnHealthChanged;
    public event Action OnHealthEnded;
    

    void Start()
    {
        Health = MaxHealth;
    }

    public void Damage(AttackData attackData)
    {
        float healthDelta = attackData.Damage;
        Health -= attackData.Damage;

        OnHealthChanged?.Invoke(healthDelta);

        if (Health <= 0)
        {
            OnHealthEnded?.Invoke();
            Health = 0.0f;
        }
    }

};