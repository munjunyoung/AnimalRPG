using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum UNIT_STATE { Idle, Move, Attack }
[RequireComponent(typeof(PlayerBehaviour))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject Modelobject;
    private PlayerBehaviour Pb;
    private Animator anim;
    private UNIT_STATE playerState;
    private void Start()
    {
        
        Pb = GetComponent<PlayerBehaviour>();
        anim = Modelobject.GetComponent<Animator>();
    }
    
    private void LateUpdate()
    {
        if (Pb.isMoving)
        {
            anim.speed = Pb.stickdistance;
            playerState = UNIT_STATE.Move;
        }
        else
        {
            anim.speed = 1;
            playerState = UNIT_STATE.Idle;
        }
        
        anim.SetFloat("UnitState", (float)playerState);
    }

}
