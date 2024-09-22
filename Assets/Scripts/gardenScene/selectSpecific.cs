using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class selectSpecific : MonoBehaviour, IPointerClickHandler
{
    public string itemType;
    public int itemIndex;
    private GameObject selectionManagerObj;

    private void Start()
    {
        selectionManagerObj = GameObject.Find("selectionManagerObj");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        clickedObj();
    }
    private void OnMouseDown()
    {
        clickedObj();
    }


    private void clickedObj()
    {
        switch (itemType)
        {
            case ("tool"):
                {
                    if (selectionManager.toolSelectedObj == gameObject)
                    {
                        selectionManagerObj.GetComponent<selectionManager>().deselectTool(gameObject);
                    }
                    else
                    {
                        selectionManagerObj.GetComponent<selectionManager>().selectTool(gameObject, itemIndex);
                    }
                    break;
                }
            case ("fertilizer"):
                {
                    if (selectionManager.fertilizerSelectedObj == gameObject)
                    {
                        selectionManagerObj.GetComponent<selectionManager>().deselcectFertilizer(gameObject);
                    }
                    else
                    {
                        selectionManagerObj.GetComponent<selectionManager>().selectFertilizer(gameObject);
                    }
                    break;
                }
            case ("land"):
                {
                    selectionManagerObj.GetComponent<selectionManager>().selectLand(gameObject, itemIndex);
                    break;
                }
        }


    }
}

