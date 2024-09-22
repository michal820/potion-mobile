using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class buyButton : MonoBehaviour, IPointerClickHandler
{

    windowManager wm;
    private void Start()
    {
        wm = GameObject.Find("windowManager").GetComponent<windowManager>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        wm.buy();
    }

}
