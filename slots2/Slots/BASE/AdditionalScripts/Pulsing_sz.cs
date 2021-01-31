using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Pulsing_sz : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private float scalestep = 1f;
    [SerializeField]
    private float sizer = 0.025f;
    [SerializeField]
    private float time = 0.015f;

    [SerializeField]
    bool EnableOnHover = false;

    bool courotineAllowed;
    bool continuoson;
    public Vector3 defaultscale;

    void Awake()
    {
        defaultscale = transform.localScale;
        courotineAllowed = true;
        StartCoroutine(StartPulsing());
    }

    public void Pulse_Single()
    {
        if(courotineAllowed)
        StartCoroutine(StartPulsing());
    }

    public void Pulsing_Continuos()
    {
        if (!continuoson && courotineAllowed)
        {
            StartCoroutine(CourotineLoop());
            continuoson = true;
        }

    }

    public void Pulsing_Continuos_Stop()
    {
        StopAllCoroutines();
        transform.localScale = defaultscale;
        continuoson = false;
        courotineAllowed = true;
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        if (EnableOnHover)
        {
            Pulsing_Continuos();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (EnableOnHover)
        {
            Pulsing_Continuos_Stop();
        }
    }


    private IEnumerator CourotineLoop()
    {   
            while(true)
                yield return StartPulsing();
    }


    private IEnumerator StartPulsing()
    {
        courotineAllowed = false;

        for (float i = 0; i <= 1f; i += 0.1f)
        {
            transform.localScale = new Vector3(
                (Mathf.Lerp(transform.localScale.x, transform.localScale.x + sizer, Mathf.SmoothStep(0f, scalestep, i))),
                (Mathf.Lerp(transform.localScale.y, transform.localScale.y + sizer, Mathf.SmoothStep(0f, scalestep, i))),
                (Mathf.Lerp(transform.localScale.z, transform.localScale.z + sizer, Mathf.SmoothStep(0f, scalestep, i)))
                );
            yield return new WaitForSeconds(time);
        }

        for (float i = 0; i <= 1f; i += 0.1f)
        {
            transform.localScale = new Vector3(
                (Mathf.Lerp(transform.localScale.x, transform.localScale.x - sizer, Mathf.SmoothStep(0f, scalestep, i))),
                (Mathf.Lerp(transform.localScale.y, transform.localScale.y - sizer, Mathf.SmoothStep(0f, scalestep, i))),
                (Mathf.Lerp(transform.localScale.z, transform.localScale.z - sizer, Mathf.SmoothStep(0f, scalestep, i)))
                );
            yield return new WaitForSeconds(time);
        }

        courotineAllowed = true;
    }
}


