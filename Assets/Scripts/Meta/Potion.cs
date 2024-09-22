using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Potion 
{
    private int amountOwned;
    private string spriteName;
    private ingredient[] recipe;
    private ingredient[] hints;
    private List<ingredientSet> attemptsAtThisPotion;

    public Potion(string sprite, ingredient[] recipe) 
    {
        spriteName = sprite;
        this.recipe = recipe;
        amountOwned = 0;
        hints = new ingredient[3];
        attemptsAtThisPotion = new List<ingredientSet>();
    }
    public int getAmountOwned()
    {
        return amountOwned;
    }

    public void setAmountOwned(int newAmount)
    {
        amountOwned = newAmount;
    }
    public string getSpriteName()
    {
        return spriteName;
    }
    public ingredient[] getRecipe()
    {
        return recipe;
    }
    public void setHints(ingredient[] hints)
    {
        this.hints = hints;
    }
    public ingredient[] getHints()
    {
        return hints;
    }
    public void addAttempt(ingredientSet ingrSet)
    {
        attemptsAtThisPotion.Add(ingrSet);
    }
    public List<ingredientSet> getAttemptsAtThisPotion()
    {
        return attemptsAtThisPotion;
    }
}
