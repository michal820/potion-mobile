using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class brewOnIngredient : MonoBehaviour, IPointerClickHandler
{

    public Sprite outline;
    //private GameData gameData;

    //private void Start()
    //{
    //    gameData = onGameLoad.GetGameData();

    //}

    public void OnPointerClick(PointerEventData eventData)
    {
        findIngredientInData();
        GameObject.Find("brewingSlots").GetComponent<brewingSlotsManager>().addSelected(findIngredientInData());
    }

    private ingredient findIngredientInData()
    {
        foreach (ingredient i in currentData.ingredients)
        {
            if (i != null)
            {
                if (gameObject.GetComponent<Image>().sprite.name == i.getSpriteName())
                {
                    return i;
                }
            }
        }
        return null;
        
    }

}
