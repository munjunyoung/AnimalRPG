using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : CharacterBehaviour
{
    public enum EnemyState
    {
        IDLE, MOVE, ATTACK, DEFENSE, DEAD, DAMAGED
    }
    [Header("Reference")]
    [SerializeField]
    private string animInteger = "animation";
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private EnemyStat stat;
    [SerializeField]
    private NavMeshAgent _navAgent;

    [Header("Runtime")]
    [SerializeField]
    private EnemyState _curState;
    [SerializeField]
    private PlayerBehaviour _target;

    private bool _bStartedAtk = false;
    private float _elapsedAtkDelay = 0;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
    }

    public override void Move()
    {
        base.Move();

        _navAgent.SetDestination(_target.transform.position);
        animator.SetInteger(animInteger, 6);
    }

    public override void Idle()
    {
        base.Idle();
        animator.SetInteger(animInteger, 0);
    }

    public override void Dead()
    {
        base.Dead();
        animator.SetInteger(animInteger, 5);
    }

    public override void Damaged()
    {
        base.Damaged();
        animator.SetInteger(animInteger, 7);
    }

    public override void Attack()
    {
        base.Attack();

        if (!_bStartedAtk)
        {
            _bStartedAtk = true;
            animator.SetInteger(animInteger, 1);
        }
        else
        {
            _elapsedAtkDelay += Time.fixedDeltaTime;
            animator.SetInteger(animInteger, 0);
            if(_elapsedAtkDelay >= stat.atkSpeed)
            {
                _elapsedAtkDelay = 0;
                _bStartedAtk = false;
            }
        }
    }

    public override void OnAnimStartAttack()
    {
        Debug.Log(gameObject.GetInstanceID());
        base.OnAnimStartAttack();
    }

    public override void OnAnimDamageTo()
    {

    }

    public override void OnAnimEndAttack()
    {
        base.OnAnimEndAttack();

        _curState = EnemyState.IDLE;
    }

    protected override void Awake()
    {
        base.Awake();

        _curState = EnemyState.MOVE;
        _navAgent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        _target = LevelManager.Instance.player;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if(_target != null)
        {
            var dist = Vector3.Distance(transform.position, _target.transform.position);
            if (dist < 2)
            {
                _curState = EnemyState.ATTACK;
            }
            else if (dist < 8)
            {
                _curState = EnemyState.MOVE;
            }
            else
            {
                _curState = EnemyState.IDLE;
            }
        }

        if(_curState == EnemyState.IDLE)
        {
            Idle();
        }
        else if(_curState == EnemyState.MOVE)
        {
            Move();
        }
        else if (_curState == EnemyState.ATTACK)
        {
            Attack();
        }
        else if (_curState == EnemyState.DAMAGED)
        {
            //Damaged();
        }
        else if (_curState == EnemyState.DEFENSE)
        {
            //Defense();
        }
        else if (_curState == EnemyState.DEAD)
        {
            //Dead();
        }
    }
}
