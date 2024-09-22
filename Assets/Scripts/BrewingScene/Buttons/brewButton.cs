using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brewButton : MonoBehaviour
{
    public GameObject brewingSlot1;
    public GameObject brewingSlot2;
    public GameObject brewingSlot3;
    public Sprite outline;
    private ingredient[] selectedIngredients;

    private void OnMouseDown()
    {
        selectedIngredients = brewingSlotsManager.selectedIngredients;

        bool wasFound = false;
        foreach (Potion potion in currentData.potions)
        {
            if(arrayIsEqual(potion.getRecipe(), selectedIngredients))
            {
                int currentAmount = potion.getAmountOwned();
                potion.setAmountOwned(currentAmount + 1);
                wasFound = true;
                currentData.seedsLeft = currentData.seedsLeft + 3;
                potion.setHints(potion.getRecipe());
                break;
            }
        }
        if (!wasFound)
        {
            currentData.seedsLeft = currentData.seedsLeft + 3;
            updateHints();
            if (selectedIngredients[0] != null && selectedIngredients[1] != null && selectedIngredients[2] != null) {
                ingredientSet thisAttempt = new ingredientSet(selectedIngredients[0], selectedIngredients[1], selectedIngredients[2]);
                currentData.failedAttempts.Add(thisAttempt);
            }
           
        }
    
        brewingSlot1.GetComponent<SpriteRenderer>().sprite = outline;
        brewingSlot2.GetComponent<SpriteRenderer>().sprite = outline;
        brewingSlot3.GetComponent<SpriteRenderer>().sprite = outline;
        selectedIngredients[0] = null;
        selectedIngredients[1] = null;
        selectedIngredients[2] = null;


        
        GameObject.Find("organizeInventory").GetComponent<brewOrganizeInventory>().updateSlotList();

    }

    private bool arrayIsEqual(ingredient[] one, ingredient[] two)
    {
        if (one  ==  null || two==null|| one.Length != two.Length)
        {
            return false;
        }

        for (int i = 0; i < one.Length; i++)
        {
            if (!one[i].Equals(two[i]))
            {
                return false;
            }
        }
        return true;
    }

    private void updateHints()
    {
        ingredientSet selectedIngrSet = new ingredientSet(selectedIngredients[0], selectedIngredients[1], selectedIngredients[2]);
        List<Potion> potionsWithSamePattern = selectedIngrSet.getPotionPatternMatch();
        bool foundPatternMatch = false;

        foreach(Potion p in potionsWithSamePattern)
        {
            p.addAttempt(selectedIngrSet);
            foundPatternMatch = true;

            ingredient[] hints = p.getHints();
            for (int i = 0; i < 3; i++)
            {
                if(p.getRecipe()[i].Equals(selectedIngredients[i]))
                {
                    hints[i] = selectedIngredients[i];
                }
            }
            p.setHints(hints);
        }
        if (!foundPatternMatch)
        {
            currentData.failedAttempts.Add(selectedIngrSet);
        }
    }

}
