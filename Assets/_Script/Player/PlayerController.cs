using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerBehaviour))]
public class PlayerController : MonoBehaviour
{
    private GameObject Model;
    private PlayerBehaviour Pb;
    private Animator anim;
    
    //Move
    public Vector2 moveDirection = Vector2.zero;
    private float speed = 1f;
    
    private void Start()
    {
        Pb = GetComponent<PlayerBehaviour>();
        Model = transform.Find("[Prefab]Model").gameObject;
        anim = Model.GetComponent<Animator>();

    }

    private void FixedUpdate()
    {
        Pb.Move(new Vector3(moveDirection.x, 0, moveDirection.y));
    }


    private void GetDirInKeyboard()
    {

    }
    
}
