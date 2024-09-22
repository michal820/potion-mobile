using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class seedManager : MonoBehaviour
{
    public GameObject seedParent;
    public GameObject seedText;
    public Sprite seedSprite;
    public GameObject fertParent;
    public GameObject windowManagerObj;
    public GameObject selectionManagerObj;

    private bool ingredientWasHarvested;

    private void harvestIngredient(int soilIndex)
    {
        Plot plotInData = currentData.plots[selectionManager.landSelectedInt, soilIndex];
        if (plotInData.getPlantedIngredient() != null)
        {
            ingredientWasHarvested = true;
            //foreach (ingredient ingr in currentData.ingredients)
            //{
            //    if (ingr.Equals(currentData.plots[selectionManager.landSelectedInt, soilIndex].getPlantedIngredient()))
            //    {
            //        int i = ingr.getAmountOwned();
            //        ingr.setAmountOwned(i + 1);
            //    }
            //}
            int i = plotInData.getPlantedIngredient().getAmountOwned();
            plotInData.getPlantedIngredient().setAmountOwned(i + 1);
            

            seedParent.GetComponent<Transform>().GetChild(soilIndex).GetComponent<SpriteRenderer>().enabled = false;
            currentData.plots[selectionManager.landSelectedInt, soilIndex].setIsPlanted(false);
            currentData.plots[selectionManager.landSelectedInt, soilIndex].setPlantedIngredient(null);
        }
    }

    private void plantSeed(int soilIndex)
    {
        Plot plot = currentData.plots[selectionManager.landSelectedInt, soilIndex];
        Transform seed = seedParent.GetComponent<Transform>().GetChild(soilIndex);
        Transform fert = fertParent.GetComponent<Transform>().GetChild(soilIndex);

        if (!plot.GetIsPlanted() && currentData.seedsLeft > 0 && plot.getPlantedIngredient() == null)
        {
            currentData.seedsLeft -= 1;
            seedText.GetComponent<Text>().text = "seeds: " + currentData.seedsLeft.ToString();

            plot.setIsPlanted(true);
            plot.setDateTime(DateTime.Now);
            seed.GetComponent<seeds>().setStartTime(plot.getStartTime());
            if (selectionManager.fertilizerSelected != null)
            {
                plot.setFertilizer(selectionManager.fertilizerSelected);
            }

            seed.GetComponent<SpriteRenderer>().sprite = seedSprite;
            seed.GetComponent<SpriteRenderer>().enabled = true;

            plot.setFertilizer(selectionManager.fertilizerSelected);
            if (selectionManager.fertilizerSelected != null)
            {
                selectionManager.fertilizerSelected.subtractAmount(1);
                if (selectionManager.fertilizerSelected.getAmount() == 0)
                {
                    selectionManager.fertilizerSelected = null;
                    selectionManager.fertilizerSelectedObj = null;
                }
            }
            fert.GetComponent<fertilizerDrop>().refresh();
            windowManagerObj.GetComponent<windowManagerGarden>().refreshFertilizers();            
        }
    }

    private List<int> getSoilIndexesBasedOnToolSelected(int soilID)
    {
        List<int> soilIndexes = new List<int>();

        switch (selectionManager.toolSelectedInt)
        {
            case (0):
                {
                    soilIndexes.Add(soilID);
                    break;
                }
            case (1):
                {
                    //add the row that the player clicked on-- soilId%3 is the row number,3*"" is the firt index in the row, ""+2 is the size of a row
                    for (int i = 3 * (soilID / 3); i < 3 * (soilID / 3) + 3; i++)
                    {
                        soilIndexes.Add(i);
                    }
                    break;
                }
            case (2):
                {
                    for (int i = 0; i < 6; i++)
                    {
                        if (soilID < 6)
                        {
                            soilIndexes.Add(i);
                        }
                        else
                        {
                            soilIndexes.Add(i + 6);
                        }
                    }
                    break;
                }
            case (3):
                {
                    for(int i = 0; i < 12; i++)
                    {
                        soilIndexes.Add(i);
                    }
                    break;
                }
        }

        return soilIndexes;
    }

    public void soilClicked(int soilID)
    {
        //harvest all ingredients in the index range
        foreach (int soilIndex in getSoilIndexesBasedOnToolSelected(soilID))
        {
            harvestIngredient(soilIndex);
        }

        //if there were no ingredients to collect, fill soil range with seeds
        if (!ingredientWasHarvested)
        {
            if (selectionManager.fertilizerSelected == null)
            {
                foreach (int soilIndex in getSoilIndexesBasedOnToolSelected(soilID))
                {
                    plantSeed(soilIndex);
                }

            }
            else
            {
                int fertLeft = selectionManager.fertilizerSelected.getAmount();
                int soilAmnt = getSoilIndexesBasedOnToolSelected(soilID).Count;
                List<int> indexes = getSoilIndexesBasedOnToolSelected(soilID);
                for (int i = 0; i < fertLeft && i < soilAmnt; i++)
                {
                    plantSeed(indexes[i]);
                }
                //selectionManagerObj.GetComponent<selectionManager>().selectFertilizer(selectionManager.fertilizerSelectedObj);
            }
        }

        ingredientWasHarvested = false;
    }
}
