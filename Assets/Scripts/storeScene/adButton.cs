using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class adButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject seedsText;
    public void OnPointerClick(PointerEventData eventData)
    {       
        GameObject.Find("adManager").GetComponent<adManager>().showRewardedAd();
        seedsText.GetComponent<Text>().text = "seeds: " + currentData.seedsLeft;
    }
}
