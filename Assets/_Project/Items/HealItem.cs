using UnityEngine;

public class HealItem : Item
{
    public override void Apply()
    {
        var attackData = new AttackData();
        attackData.Damage = -20.0f;
        // TODO add health to player
        TankRoot.Instance.Transform.GetComponent<HealthComponent>().Damage(attackData);
        base.Apply();
    }
}
