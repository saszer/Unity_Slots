using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArrowButtonScroller : MonoBehaviour, IPointerEnterHandler , IPointerExitHandler
{
    [SerializeField]
    private ScrollRectScript scrollrectscript = null;
    [SerializeField]
    private bool isOppositeButton = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isOppositeButton)
        {
            scrollrectscript.ButtonDownPressed();
        }
        else if(!isOppositeButton)
        {
            scrollrectscript.ButtonUpPressed();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        scrollrectscript.ButtonLift();
    }
}
