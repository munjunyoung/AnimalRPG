using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectHitSc : MonoBehaviour
{
    protected PlayerBehaviour pb;
    protected int damage;
    protected float effectRunningtime;

    private void Awake()
    {
        effectRunningtime = 0.5f;
    }

    public virtual void SetData(PlayerBehaviour _pb)
    {
        pb = _pb;
    }

    protected virtual void OnEnable()
    {
        StartCoroutine(EffectOffProcess(effectRunningtime));
    }
    
    protected void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            //parmeter damage
            other.GetComponent<EnemyBehaviour>().TakeDamage(damage);
        }
    }

    IEnumerator EffectOffProcess(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}
