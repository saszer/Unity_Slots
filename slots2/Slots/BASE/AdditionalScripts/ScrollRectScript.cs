using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollRectScript : MonoBehaviour
{
    private ScrollRect scrollrect;
    private bool mousehover, mousedown, isbuttondown, isbuttonup;
    [SerializeField]
    private float speed = 0.05f;
    [SerializeField]
    private float mouseDownSpeedMultiplier = 0.05f;
    void Start()
    {
        scrollrect = GetComponent<ScrollRect>();
    }

    private void Update()
    {
        if (mousehover)
        {
            if (isbuttondown)
            {
                ScrollDown();
            }
            else if (isbuttonup)
            {
                ScrollUp();
            }
        }
    }

    public void ButtonDownPressed()
    {
        mousehover = true;
        isbuttondown = true;
    }

    public void ButtonUpPressed()
    {
        mousehover = true;
        isbuttonup = true;
    }

    public void ButtonLift()
    {
        mousehover = false;
        isbuttonup = false;
        isbuttondown = false;
    }

    private void ScrollDown()
    {
        if (Input.GetMouseButton(0)){
            scrollrect.horizontalNormalizedPosition -= speed * mouseDownSpeedMultiplier;
        }
        else
        {
            scrollrect.horizontalNormalizedPosition -= speed;
        }

    }

    private void ScrollUp()
    {
        if (Input.GetMouseButton(0))
        {
            scrollrect.horizontalNormalizedPosition += speed * mouseDownSpeedMultiplier;
        }
        else
        {
            scrollrect.horizontalNormalizedPosition += speed;
        }
    }
}

