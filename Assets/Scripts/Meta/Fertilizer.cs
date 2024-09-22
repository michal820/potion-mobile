using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public enum FertilizerType
{
    None,
    RareRarity,
    EpicRarity,
    LegendaryRarity,
    TwoxSpeed,
    FivexSpeed,
    TenxSpeed,
    FlowerType,
    CropType,
    GreenType,
    BugType,
    RockType,
    OrganType,
    SpecialType
}

[Serializable]
public class Fertilizer
{
    FertilizerType type;
    int amountOwned;
    string name;
    string description;
    int price;
    string spriteName;
    string colorOrText;
    public Fertilizer(FertilizerType type, string name, string description, int price,
        string spriteName, string colorOrText)
    {
        this.name = name;
        this.description = description;
        this.type = type;
        amountOwned = 0;
        this.price = price;
        this.spriteName = spriteName;
        this.colorOrText = colorOrText;
    }
    public void addAmount(int amount)
    {
        amountOwned += amount;
    }
    public void subtractAmount(int amount)
    {
        amountOwned -= amount;
    }
    public int getAmount()
    {
        return amountOwned;
    }
    public string getName()
    {
        return name;
    }
    public string getDescription()
    {
        return description;
    }
    public int getPrice()
    {
        return price;
    }
    public string getSpriteName()
    {
        return spriteName;
    }
    public string getColorOrText()
    {
        return colorOrText;
    }
    public FertilizerType getFertilizerType()
    {
        return type;
    }
    public Fertilizer returnThisFertIfTypeMatches(FertilizerType fertType)
    {
        if(fertType == type)
        {
            return this;
        }
        else
        {
            return null;
        }
    }

}