using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class JoyStick : MonoBehaviour, IEndDragHandler , IDragHandler
{
    [SerializeField]
    private PlayerController player;
    [SerializeField]
    private RectTransform stick;
    private float radius;
    private Vector2 stickStartPos;
    public Vector2 joystickDir;
    public bool isMoving = false;

    private void Start()
    {
        stickStartPos = stick.position;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        //스틱 반지름 scale은 처리 하지 않음
        radius = GetComponent<RectTransform>().sizeDelta.y * 0.5f;
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        //방향벡터
        joystickDir = (eventData.position - stickStartPos).normalized;
        //일정거리보다 클경우 
        stick.position = Vector2.Distance(eventData.position, stickStartPos) > radius ? stickStartPos + joystickDir * radius : eventData.position;
        player.moveDirection = joystickDir;
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        stick.position = stickStartPos;
        player.moveDirection = Vector2.zero;

    }
}
