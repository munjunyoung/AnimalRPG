using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : CharacterBehaviour
{
    public override void Move(Vector3 dir)
    {
        
        base.Move(dir);
        characterController.transform.rotation = Quaternion.LookRotation(dir);
        dir.y -= 9.8f * Time.deltaTime; 
        characterController.Move(dir * Time.deltaTime);    
        
    }
}
