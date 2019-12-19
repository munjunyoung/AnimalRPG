using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    public Camera cam;

    [SerializeField]
    private Transform Target;
    private Vector3 offset;
    private float smoothing = 5f;
    

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    private void Start()
    {
        offset = transform.position - Target.position;
    }

    private void FixedUpdate()
    {
        var targetCampos = Target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCampos, smoothing * Time.deltaTime);
    }   



}
