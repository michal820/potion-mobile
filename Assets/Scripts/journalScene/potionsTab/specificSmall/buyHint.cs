using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class buyHint : MonoBehaviour, IPointerClickHandler
{
    public GameObject hintWindowManager;

    public void OnPointerClick(PointerEventData eventData)
    {
        hintWindowManager.GetComponent<hintManager>().buyHint();
    }
}
