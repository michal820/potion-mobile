using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class amountSpecific : MonoBehaviour, IPointerClickHandler
{
    public int amountVal;
    public GameObject buyButton;
    public GameObject windowManager;
    public void OnPointerClick(PointerEventData eventData)
    {
        windowManager.GetComponent<windowManager>().updateAmountVal(amountVal);
        windowManager.GetComponent<windowManager>().changeSelectedAmount(gameObject);     
    }


}
