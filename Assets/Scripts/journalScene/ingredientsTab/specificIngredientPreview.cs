using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class specificIngredientPreview : MonoBehaviour
{
    public GameObject ingredientTabManager;
    
    private void OnMouseDown()
    {
        string spriteName = this.gameObject.GetComponent<Image>().sprite.name;
        ingredient clickedIngredient = null;
        foreach(ingredient i in currentData.ingredients)
        {
            if (i.getIngredientBySpriteName(spriteName) != null)
            {
                clickedIngredient = i;
                break;
            }
        }
        if (clickedIngredient != null)
        {
            ingredientTabManager.GetComponent<ingredientTabManager>().displayIngredientDetails(clickedIngredient);
        }        
    }
}
