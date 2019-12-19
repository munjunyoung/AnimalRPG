using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class JoyStick : MonoBehaviour, IEndDragHandler , IDragHandler, IBeginDragHandler
{
    [SerializeField]
    private PlayerBehaviour player;
    [SerializeField]
    private RectTransform stick;
    private Vector2 stickStartPos;
    public Vector2 joystickDir;
    private float radius;
    //PressColor
    private Image stickImage;
    private Color originalColor;
    private Color pressColor;


    private void Start()
    {
        stickStartPos = stick.position;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
        //스틱 반지름 scale은 처리 하지 않음
        radius = GetComponent<RectTransform>().sizeDelta.y * 0.5f;
        //PressColor
        stickImage = stick.GetComponent<Image>();
        originalColor = stickImage.color;
        pressColor = originalColor * 0.6f;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        stickImage.color = pressColor;
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
        stickImage.color = originalColor;
    }

}
