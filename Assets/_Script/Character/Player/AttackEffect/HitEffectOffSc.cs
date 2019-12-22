using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffectOffSc : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable()
    {
        StartCoroutine(EffectOFFProcess(0.5f));
    }

    IEnumerator EffectOFFProcess(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
