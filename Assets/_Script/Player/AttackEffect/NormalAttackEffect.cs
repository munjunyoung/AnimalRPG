using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttackEffect : MonoBehaviour
{
    public PlayerBehaviour pb;
    private ParticleSystem ps;
    private int damage;
    
    private void Awake()
    {
        ps = GetComponent<ParticleSystem>();
        pb.GetComponentInParent<PlayerBehaviour>();
    }

    public void SetData(PlayerBehaviour _pb)
    {
        pb = _pb;
    }

    private void OnEnable()
    {
        damage = pb.ability.AttackDamage;
        StartCoroutine(EffectOffProcess(0.5f));
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            //parmeter damage
            other.GetComponent<EnemyBehaviour>().Damaged();
        }
    }

    IEnumerator EffectOffProcess(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}
