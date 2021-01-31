using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeTextOnHover : MonoBehaviour, IPointerEnterHandler
{   
    [SerializeField]
    private Text _textbox = null;
    public string text = "";
    public void OnPointerEnter(PointerEventData eventData)
    {
        _textbox.text = text;
    }
}
