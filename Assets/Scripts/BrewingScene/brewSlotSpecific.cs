using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class brewSlotSpecific : MonoBehaviour
{
    public Sprite outline;
    public int slotID;
    //private GameData gameData;

    //private void Start()
    //{
    //    gameData  = onGameLoad.GetGameData();
    //}

    private void OnMouseDown()
    {
        if (gameObject.GetComponent<SpriteRenderer>().sprite != outline)
        {
            ingredient ingrToRemove = findIngredientInData();
            GameObject.Find("brewingSlots").GetComponent<brewingSlotsManager>().removeIngredientFromSlot(ingrToRemove, slotID);
        }

    }

    private ingredient findIngredientInData()
    {
        foreach (ingredient i in currentData.ingredients)
        {
            if (i != null)
            {
                if (gameObject.GetComponent<SpriteRenderer>().sprite.name == i.getSpriteName())
                {
                    return i;
                }
            }
        }
        return null;

    }
}
