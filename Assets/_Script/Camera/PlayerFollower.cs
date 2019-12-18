using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    public Camera cam;

    public Transform follower;

    

    private void Awake()
    {
        cam = GetComponent<Camera>();

    }
}
