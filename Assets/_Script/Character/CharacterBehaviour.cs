using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    protected CharacterController characterController;

    protected virtual void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    public virtual void Move(Vector3 dir)
    {
        
    }

    public virtual void Move ()
    {

    }

    public virtual void Attack()
    {

    }

    public virtual void CastSkill()
    {

    }
}
