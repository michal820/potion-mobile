using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class windowToggler : MonoBehaviour, IPointerClickHandler
{
    public bool switchTo;
    public GameObject windowManager;

    public void OnPointerClick(PointerEventData eventData)
    {
        windowManager.GetComponent<windowManagerGarden>().toggleWindow(switchTo);
    }
    public void OnMouseDown()
    {
        windowManager.GetComponent<windowManagerGarden>().toggleWindow(switchTo);
    }
}
