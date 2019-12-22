using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum PlayerState { Idle, Move, Attack, Skill, Dead }
public class PlayerBehaviour : CharacterBehaviour
{
    private Animator anim;
    private PlayerState playerState;
    //Ability
    public PlayerStat ability;
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
            else if (_CurrentHp > ability.totalHp)
                _CurrentHp = ability.totalHp;
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
    private AttackEffectSc[] NormalAttackEffectArray;
    private int normalAttackEffectCount = 0;
    private HitEffectOffSc[] normalAttackHitEffectArray;
    private int normalAttackHitEffectCount = 0;
    //Skill
    [SerializeField]
    private Transform skillEffectPosition;
    private AttackEffectSc skillEffect;
    private HitEffectOffSc[] skillAttackHitEffectArray;
    private int skillAttackHitEffectCount = 0;
    
    public bool isMoving = false;
    public bool isStartAttack = false;
    public bool isStartSkill = false;
    public bool isRunningCooltimeSkill = false;

    protected override void Awake()
    {
        base.Awake();
        ability = new PlayerStat();
        anim = characterAnimReceiver.GetComponent<Animator>();
    }

    protected override void Start()
    {
        base.Start();
        
        //Attack Effect
        NormalAttackEffectArray = NormalAttackEffectPosition.GetComponentsInChildren<AttackEffectSc>(true);
        foreach(var ep in NormalAttackEffectArray)
            ep.SetData(this);
        var normalHitParent = transform.Find("SkillAttackHitParent").transform;
        normalAttackHitEffectArray = normalHitParent.GetComponentsInChildren<HitEffectOffSc>(true);

        //Skill Effect
        skillEffect = skillEffectPosition.GetComponentInChildren<SkillAttackEffectHitSc>(true);
        skillEffect.SetData(this);
        var skillHitparent = transform.Find("NormalAttackHitParent").transform;
        skillAttackHitEffectArray = skillHitparent.GetComponentsInChildren<HitEffectOffSc>(true);
    }
    
    protected override void FixedUpdate()
    {
        if (!isAlive)
            return;
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
        NormalAttackEffectArray[normalAttackEffectCount].gameObject.SetActive(true);
        normalAttackEffectCount++;
        normalAttackEffectCount = normalAttackEffectCount % NormalAttackEffectArray.Length;
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
        PlayerProfileUIManager.instance.StartSkillCoolTime(ability.skillCoolTime);
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

    #region TakeDamage
    /// <summary>
    /// NOTE : 데미지 처리 및 애니매이션 실행, 죽음
    /// </summary>
    /// <param name="damage"></param>
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        anim.SetTrigger("TakeDamage");
        currentHP -= damage;
        if (currentHP == 0)
        {
            Dead();
        }
    }

    public override void Dead()
    {
        base.Dead();
        isAlive = false;
        anim.SetTrigger("Dead");

    }

    public void NormalAttackHitEffectPoolingProcess(Vector3 position)
    {
        normalAttackHitEffectArray[normalAttackHitEffectCount].gameObject.SetActive(true);
        normalAttackHitEffectCount++;
        normalAttackHitEffectCount %= normalAttackHitEffectArray.Length;
    }

    public void SkillHitEffectPoolingProcess(Vector3 position)
    {
        skillAttackHitEffectArray[skillAttackHitEffectCount].gameObject.SetActive(true);
        skillAttackHitEffectCount++;
        skillAttackHitEffectCount %= skillAttackHitEffectArray.Length;
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

    #endregion
}