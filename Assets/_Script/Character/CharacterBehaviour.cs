using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    protected CharacterController characterController;
    protected CharacterAnimReceiver characterAnimReceiver;

    protected virtual void Awake()
    {
        characterController = GetComponent<CharacterController>();
        if(characterAnimReceiver==null)
            characterAnimReceiver = GetComponentInChildren<CharacterAnimReceiver>();
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {

    }

    protected virtual void FixedUpdate()
    {

    }

    public virtual void Move(Vector3 dir)
    {
        
    }
    
    public virtual void Idle()
    {

    }

    public virtual void Move()
    {

    }

    public virtual void Attack()
    {

    }

    public virtual void TakeDamage(int damage)
    {

    }

    public virtual void Dead()
    {

    }

    public virtual void OnAnimStartAttack()
    {

    }

    public virtual void OnAnimDamageTo()
    {

    }
    
    public virtual void OnAnimEndAttack()
    {

    }

    public virtual void OnAnimStartSkill()
    {

    }

    public virtual void OnAnimDamageToSkill()
    {

    }

    public virtual void OnAnimEndSkill()
    {

    }
}
