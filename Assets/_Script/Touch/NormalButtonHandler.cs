using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class NormalButtonHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    protected PlayerBehaviour Pb;
    protected Image image;

    protected Color originalColor;
    protected Color pressColor;

    protected virtual void Start()
    {
        Pb = GameObject.FindWithTag("Player").GetComponent<PlayerBehaviour>();
        image = GetComponent<Image>();
        originalColor = image.color;
        pressColor = originalColor * 0.6f;
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        image.color = pressColor;
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        image.color = originalColor;
    }
}
