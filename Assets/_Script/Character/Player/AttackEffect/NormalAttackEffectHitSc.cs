using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttackEffectHitSc : EffectHitSc
{
    protected override void OnEnable()
    {
        damage = pb.ability.AttackDamage;
        base.OnEnable();
    }
}
