using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAttackEffectHitSc : EffectHitSc
{
    protected override void OnEnable()
    {
        damage = pb.ability.skillDamage;
        base.OnEnable();
    }
}
