using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class itemSpecific : MonoBehaviour, IPointerClickHandler
{
    public string objType;
    public FertilizerType fertType;
    private windowManager windowManager;
    public static bool windowOpen;

    private void Start()
    {
        windowManager = GameObject.Find("windowManager").GetComponent<windowManager>();
        windowOpen = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!windowOpen)
        {
            if (fertType == FertilizerType.None)
            {
                windowManager.turnObjWindowOn(objType);
            }
            else
            {
                windowManager.turnFertWindowOn(fertType);
            }
        }
    }

}
