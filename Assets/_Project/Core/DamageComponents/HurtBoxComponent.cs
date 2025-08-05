using UnityEngine;

public class HurtBoxComponent : MonoBehaviour
{
    public AttackData DamageAttackData;

    void OnTriggerEnter2D(Collider2D collider)
    {
        bool is_need_to_damage = collider.TryGetComponent(out HitBoxComponent hitbox) && DamageAttackData.TargetLayers == (DamageAttackData.TargetLayers | (1 << collider.gameObject.layer));
        if (is_need_to_damage)
        {
            Debug.Log("Hurted");
            hitbox.Damage(DamageAttackData);
        }
    }
}
