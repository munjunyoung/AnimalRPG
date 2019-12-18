using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class JoyStick : MonoBehaviour, IEndDragHandler , IDragHandler
{
    [SerializeField]
    private PlayerBehaviour player;
    [SerializeField]
    private RectTransform stick;
    private Vector2 stickStartPos;
    public Vector2 joystickDir;
    private float radius;

    private void Start()
    {
        stickStartPos = stick.position;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
        //스틱 반지름 scale은 처리 하지 않음
        radius = GetComponent<RectTransform>().sizeDelta.y * 0.5f;
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        //방향벡터
        joystickDir = (eventData.position - stickStartPos).normalized;
        //일정거리보다 클경우 
        stick.position = Vector2.Distance(eventData.position, stickStartPos)> radius ? stickStartPos + joystickDir * radius : eventData.position;
        player.moveDirection = new Vector3(joystickDir.x, 0, joystickDir.y);
        var distance = Vector2.Distance(stick.position, stickStartPos);
        player.isMoving = true;
        player.stickdistance = distance / radius;
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        stick.position = stickStartPos;
        player.moveDirection = new Vector3(0, 0, 0);
        player.isMoving = false;

    }
}
