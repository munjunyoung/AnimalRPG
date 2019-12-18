using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimReceiver : MonoBehaviour
{
    public CharacterBehaviour parentCharacter;

    public virtual void OnAnimDamageTo()
    {
        parentCharacter.OnAnimDamageTo();
    }

    public virtual void OnAnimStartAttack()
    {
        parentCharacter.OnAnimStartAttack();
    }

    public virtual void OnAnimEndAttack()
    {
        parentCharacter.OnAnimEndAttack();
    }
}
