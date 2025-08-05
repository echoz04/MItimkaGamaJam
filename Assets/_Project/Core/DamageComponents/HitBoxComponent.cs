using UnityEngine;

public class HitBoxComponent : MonoBehaviour
{
    public HealthComponent healthComponent;

    public void Damage(AttackData attackData)
    {
        healthComponent.Damage(attackData);
    }
}
