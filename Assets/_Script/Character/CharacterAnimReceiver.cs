using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimReceiver : MonoBehaviour
{
    
    private CharacterBehaviour parentCharacter;

    private void Start()
    {
        if(parentCharacter==null)
            parentCharacter = GetComponentInParent<CharacterBehaviour>();
    }

    /// <summary>
    /// NOTE : 피격
    /// </summary>
    public virtual void OnAnimDamageTo()
    {
        parentCharacter.OnAnimDamageTo();
    }

    /// <summary>
    /// NOTE : 공격 시작
    /// </summary>
    public virtual void OnAnimStartAttack()
    {
        parentCharacter.OnAnimStartAttack();
    }

    /// <summary>
    /// NOTE : 공격 종료
    /// </summary>
    public virtual void OnAnimEndAttack()
    {
        parentCharacter.OnAnimEndAttack();
    }

    /// <summary>
    /// NOTE : 스킬 시작
    /// </summary>
    public virtual void OnAnimStartSkill()
    {
        parentCharacter.OnAnimStartSkill();
    }

    /// <summary>
    /// NOTE : 스킬 피격
    /// </summary>
    public virtual void OnAnimDamageToSkill()
    {
        parentCharacter.OnAnimDamageToSkill();
    }

    /// <summary>
    /// NOTE : 스킬 종료
    /// </summary>
    public virtual void OnAnimEndSkill()
    {
        parentCharacter.OnAnimEndSkill();
    }
}
