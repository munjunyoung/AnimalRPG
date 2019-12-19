using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum PlayerState { Idle, Move, Attack }
public class PlayerBehaviour : CharacterBehaviour
{
    [SerializeField]
    private Animator anim;
    public AbilityData ability;

    private PlayerState playerState;
    //Move 
    public Vector3 moveDirection = Vector3.zero;
    public float stickdistance = 0;
    private float gravity = 9.8f;
    //Attack
    public Transform normalAttackEffectParent;
    public NormalAttackEffect[] EffectPooling;
    public int effectCount = 0;

    
    //조이스틱에서 처리
    public bool isMoving = false;
    public bool isStartAttack = false;
    public bool isAttacking = false;

    protected override void Start()
    {
        base.Start();
        ability = new AbilityData();
        anim = characterAnimReceiver.GetComponent<Animator>();
        //AttackEffect;
        normalAttackEffectParent = transform.Find("NormalAttackEffectPoolingParent").transform;
        EffectPooling = GetComponentsInChildren<NormalAttackEffect>(true);
        foreach(var ep in EffectPooling)
            ep.SetData(this);
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        SetAnimation();
    }

    public override void Move()
    {
        base.Move();

        //이동    
        var movedir = moveDirection;
        movedir *= stickdistance;
        movedir *= ability.moveSpeed;
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
        //Effect 생성
        
    }

    public override void OnAnimStartAttack()
    {
        base.OnAnimStartAttack();
        isAttacking = true;
        
    }

    public override void OnAnimDamageTo()
    {
        base.OnAnimDamageTo();
        EffectPooling[effectCount].gameObject.SetActive(true);
        effectCount++;
        effectCount = effectCount % EffectPooling.Length;
    }

    public override void OnAnimEndAttack()
    {
        base.OnAnimEndAttack();
        isAttacking = false;
    }
    
    private void SetAnimation()
    {
        if (isStartAttack)
        {
            anim.SetFloat("AttackSpeed", ability.AttackSpeed);
            playerState = PlayerState.Attack;
        }
        else if (isMoving)
        {
            anim.SetFloat("MoveSpeed", stickdistance);
            playerState = PlayerState.Move;
        }
        else
        {
            playerState = PlayerState.Idle;
        }

        anim.SetInteger("UnitState", (int)playerState);
    }

    private void SetKeyBoard()
    { 
    }
}

public class AbilityData
{
    public int totalHp;
    public int totalMp;
    public int moveSpeed;
    public int AttackSpeed;
    public int AttackDamage;
    
    public AbilityData()
    {
        totalHp = 100;
        totalMp = 100;
        moveSpeed = 1;
        AttackSpeed = 1;
        AttackDamage = 50;
        
    }
}
