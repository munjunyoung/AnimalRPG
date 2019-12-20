using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum PlayerState { Idle, Move, Attack, Skill }
public class PlayerBehaviour : CharacterBehaviour
{
    [SerializeField]
    public Animator anim;
    private PlayerState playerState;
    //Ability
    public AbilityData ability;
    private int _CurrentHp;
    public int currentHP
    {
        get
        {
            return _CurrentHp;
        }

        set
        {
            _CurrentHp = value;
            if (_CurrentHp < 0)
                _CurrentHp = 0;

        }
        
    }

    private int CurrentMp;
    
    //Move 
    public Vector3 moveDirection = Vector3.zero;
    public float stickdistance = 0;
    private float gravity = 9.8f;
    //Attack
    [SerializeField]
    private Transform NormalAttackEffectPosition;
    private EffectHitSc[] NormalAttackEffectPooling;
    private int effectCount = 0;
    //Skill
    [SerializeField]
    private Transform skillEffectPosition;
    private EffectHitSc skillEffect;

    public bool isMoving = false;
    public bool isStartAttack = false;
    public bool isStartSkill = false;
    public bool isRunningCooltimeSkill = false;

    protected override void Awake()
    {
        base.Awake();
        ability = new AbilityData();
        anim = characterAnimReceiver.GetComponent<Animator>();
    }

    protected override void Start()
    {
        base.Start();
        
        //Attack
        NormalAttackEffectPooling = NormalAttackEffectPosition.GetComponentsInChildren<EffectHitSc>(true);
        foreach(var ep in NormalAttackEffectPooling)
            ep.SetData(this);
        
        //Skill
        skillEffect = skillEffectPosition.GetComponentInChildren<SkillAttackEffectHitSc>(true);
        skillEffect.SetData(this);
    }
    
    protected override void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        SetAnimation();
    }

    #region  Move
    /// <summary>
    /// NOTE : 조이스틱 stickdistance 거리를 통한 이동 속도 조절, 및 movedirection 방향 초기화 이동은 rotation에 상관없이 움직이므로 roation 또한 방향벡터를 이용하여 직접 회전
    /// </summary>
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
    #endregion

    #region Attack

    public override void Attack()
    {
        base.Attack();
        //Effect 생성
        
    }

    public override void OnAnimStartAttack()
    {
        base.OnAnimStartAttack();
    }

    public override void OnAnimDamageTo()
    {
        base.OnAnimDamageTo();
        NormalAttackEffectPooling[effectCount].gameObject.SetActive(true);
        effectCount++;
        effectCount = effectCount % NormalAttackEffectPooling.Length;
    }

    public override void OnAnimEndAttack()
    {
        base.OnAnimEndAttack();
    }
    #endregion

    #region Skill
    public override void OnAnimStartSkill()
    {
        base.OnAnimStartSkill();
        UIManager.instance.StartSkillCoolTime(ability.skillCoolTime);
        //쿨타임 실행
        //애니매이션 실행
    }

    public override void OnAnimDamageToSkill()
    {
        base.OnAnimDamageToSkill();
        skillEffect.gameObject.SetActive(true);

    }

    public override void OnAnimEndSkill()
    {
        base.OnAnimEndSkill();
    }
    #endregion

    #region Animation
    private void SetAnimation()
    {
        if(isStartSkill)
        {
            if(!isRunningCooltimeSkill)
            playerState = PlayerState.Skill;
        }
        else if (isStartAttack)
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

    #endregion

    #region ETC
    private void SetKeyBoard()
    { 
        
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

    }
    #endregion
}

public class AbilityData
{
    public int Level;
    public int totalHp;
    public int totalMp;

    public int moveSpeed;

    public int AttackSpeed;
    public int AttackDamage;

    public int skillDamage;
    public float skillCoolTime;

    public AbilityData()
    {
        totalHp = 100;
        totalMp = 100;
        moveSpeed = 5;
        AttackSpeed = 1;
        AttackDamage = 50;
        skillCoolTime = 5f;
        skillDamage = 200;
    }
}
