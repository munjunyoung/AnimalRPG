using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : CharacterBehaviour
{
    //Move 
    public Vector3 moveDirection = Vector3.zero;
    public float stickdistance = 0;
    private float Speed = 2;
    private float gravity = 9.8f;
    //조이스틱에서 처리
    public bool isMoving = false;

    public bool isAttack = false;

    private void FixedUpdate()
    {
        Move();
    }
    
    public override void Move()
    {
        base.Move();

        //이동    
        var movedir = moveDirection;
        movedir *= stickdistance;
        movedir *= Speed;
        movedir.y -= gravity * Time.deltaTime;;
        characterController.Move(movedir * Time.deltaTime);
        //방향
        var rotDir = moveDirection;
        rotDir = rotDir.normalized;
        if (rotDir != Vector3.zero)
            characterController.transform.rotation = Quaternion.LookRotation(rotDir);

    }

    public override void Attack()
    {
        base.Attack();
        
    }
}
