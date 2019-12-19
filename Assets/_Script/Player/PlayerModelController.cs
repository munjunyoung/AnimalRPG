using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerModelController : MonoBehaviour
{
    [SerializeField]
    private PlayerBehaviour Pb;
    private void Start()
    {
        Pb = GetComponentInParent<PlayerBehaviour>();
    }

    public void StartAttackInAnim()
    {
        Pb.OnAnimStartAttack();
    }

    public void EndAttackInAnim()
    {
        Pb.OnAnimEndAttack();
    }

}
