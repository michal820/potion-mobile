using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class closeWindowButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject windowManager;
    private windowManager wm;
    private void Start()
    {
        wm = windowManager.GetComponent<windowManager>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        wm.turnWindowOff();
    }
}
