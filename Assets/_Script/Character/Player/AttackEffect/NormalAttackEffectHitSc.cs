using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttackEffectHitSc : AttackEffectSc
{
    protected override void OnEnable()
    {
        damage = pb.ability.AttackDamage;
        base.OnEnable();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (other.CompareTag("Enemy"))
        {
            //parmeter damage
            other.GetComponent<EnemyBehaviour>().TakeDamage(damage);
            pb.NormalAttackHitEffectPoolingProcess(this.transform.position);
        }
    }
}
