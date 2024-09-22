using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ingredient
{
    private int growTime;
    private int amountOwned;
    private string spriteName;
    private int rarity; //from 1-7, 1  = rare, 7 = common
    private string type;
    private string name;
    private bool isUnlocked;

    public ingredient(string  name, string sprite, string type, int rarity, int growTime)
    {
        this.growTime = growTime;
        spriteName = sprite;
        this.rarity = rarity;
        this.type = type;
        this.name = name;
        amountOwned = 0;
        isUnlocked = false;
        if (amountOwned != 0) { isUnlocked = true; }       
    }

    public int getGrowTime()
    {
        return growTime;
    }

    public int getAmountOwned()
    {
        return amountOwned;
    }

    public void setAmountOwned (int newAmount)
    {
        if (newAmount!=0)
        {
            isUnlocked = true;
        }
        amountOwned = newAmount;
    }
    public string getSpriteName()
    {
        return spriteName;
    }
    public string getName()
    {
        return name;
    }
    public int getRarity()
    {
        return rarity;
    }
    public string getRarityString()
    {
        switch  (rarity){
            case 1:
                return "common";
            case 2:
                return "uncommon";
            case 3:
                return "strange";
            case 4:
                return "strange2";
            case 5:
                return "rare";
            case 6:
                return "rare2";
            case 7:
                return "bizzare";
        }
        return null;
    }
    public void setRarity(int newRarity)
    {
        rarity = newRarity;
    }
    public void setGrowTime(int newGrowTime)
    {
        growTime = newGrowTime;
    }
    public string getType()
    {
        return type;
    }
    public  string getHexColor()
    {
        string hexColor;
        switch (type)
        {
            case "flower":
                hexColor = "#E4A791";
                break;
            case "crop":
                hexColor = "#D4A317";
                break;
            case "green":
                hexColor = "#A6BA78";
                break;
            case "bug":
                hexColor = "#877A91";
                break;
            case "rock":
                hexColor = "#7992AB";
                break;
            case "organ":
                hexColor = "#B76865";
                break;
            case "special":
                hexColor = "#686868";
                break;
            default:
                hexColor = "#000000";
                break;
        }
        return hexColor;
    }

    public bool getIsUnlocked()
    {
        return isUnlocked;
    }

    public ingredient getIngredientBySpriteName(string name)
    {
        if(name == spriteName)
        {
            return this;
        }
        return null;
    }

    public bool Equals(ingredient other)
    {
        if (other == null || !(other is ingredient))
        {
            return false;
        }

        if (this.growTime != other.growTime ||
            this.amountOwned != other.amountOwned ||
            this.spriteName != other.spriteName ||
            this.rarity != other.rarity)
        {
            return false;
        }

        return true;
    }
}
