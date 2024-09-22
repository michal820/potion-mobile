using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Plot 
{
    private bool isPlanted;
    private DateTime soilStartTime;
    private ingredient plantedIngredient;
    private Fertilizer fertilizer;

    public Plot()
    {
        isPlanted = false;
        plantedIngredient = null;
        soilStartTime = new DateTime();
        fertilizer = null;
    }


    public bool GetIsPlanted()
    {
        return isPlanted;
    }
    public void setIsPlanted(bool set)
    {
        isPlanted = set;
    }



    public DateTime getStartTime()
    {
        return soilStartTime;
    }
    public void setDateTime(DateTime set)
    {
        soilStartTime = set;
    }



    public ingredient getPlantedIngredient()
    {
        return plantedIngredient;
    }
    public void setPlantedIngredient(ingredient set)
    {
        plantedIngredient = set;
    }



    public Fertilizer GetFertilizer()
    {
        return fertilizer;
    }
    public void setFertilizer(Fertilizer set)
    {
        fertilizer = set;
    }
}
