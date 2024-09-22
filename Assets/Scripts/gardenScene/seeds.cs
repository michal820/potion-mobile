using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[DisallowMultipleComponent]
public class seeds : MonoBehaviour
{
    private SpriteRenderer spriteRend;
    private long timeSpeed;
    private Text seedText;
    public int soilID;
    public Sprite seedSprite;
    private DateTime StartTime;

    Plot correspondingPlotInData;
    public GameObject correspondingFertObj;


    // render seeds/ingridient/nothing, manage time elapsed counter
    public void Start()
    {
        timeSpeed = 10;
        spriteRend = GetComponent<SpriteRenderer>();
        seedText = GameObject.Find("seedText").GetComponent<Text>();
        correspondingPlotInData = currentData.plots[selectionManager.landSelectedInt, soilID];

        if (!correspondingPlotInData.GetIsPlanted())
        {
            spriteRend.enabled = false;
        }
        else
        {
            spriteRend.enabled = true;
            spriteRend.sprite = seedSprite;
            StartTime = correspondingPlotInData.getStartTime();
        }
        if (correspondingPlotInData.getPlantedIngredient() != null)
        {
            renderIngredient();
        }

        seedText.text = "seeds: " + currentData.seedsLeft.ToString();
    }


    private void OnMouseDown()
    {
        GameObject.Find("seedManagerObj").GetComponent<seedManager>().soilClicked(soilID);

    }


    public void setStartTime(DateTime startTime)
    {
        StartTime = startTime;
    }

    private void timePassed()
    {
        if (correspondingPlotInData.GetIsPlanted() && correspondingPlotInData.getPlantedIngredient() == null)
        {
            TimeSpan elapsed = DateTime.Now - StartTime;
            if (elapsed.TotalSeconds > timeSpeed)
            {
                correspondingPlotInData.setPlantedIngredient(chooseRandomIngredient());

                correspondingPlotInData.setIsPlanted(false);
                spriteRend.enabled = false;

                correspondingFertObj.GetComponent<SpriteRenderer>().enabled = false;
                correspondingPlotInData.setFertilizer(null);

                renderIngredient();

            }
        }
    }


    private ingredient chooseRandomIngredient()
    {

        if (correspondingPlotInData.GetFertilizer() != null)
        {
            switch (correspondingPlotInData.GetFertilizer().getFertilizerType())
            {
                case (FertilizerType.FlowerType):
                    {
                        int index = getIndexToChooseRandomIngridient(currentData.flowerIngredients);
                        return currentData.flowerIngredients[index];
                    }
                case (FertilizerType.CropType):
                    {
                        int index = getIndexToChooseRandomIngridient(currentData.cropIngredients);
                        return currentData.cropIngredients[index];
                    }
                case (FertilizerType.GreenType):
                    {
                        int index = getIndexToChooseRandomIngridient(currentData.greenIngredients);
                        return currentData.greenIngredients[index];
                    }
                case (FertilizerType.BugType):
                    {
                        int index = getIndexToChooseRandomIngridient(currentData.bugIngredients);
                        return currentData.bugIngredients[index];
                    }
                case (FertilizerType.RockType):
                    {
                        int index = getIndexToChooseRandomIngridient(currentData.rockIngredients);
                        return currentData.rockIngredients[index];
                    }
                case (FertilizerType.OrganType):
                    {
                        int index = getIndexToChooseRandomIngridient(currentData.organIngredients);
                        return currentData.organIngredients[index];
                    }
                case (FertilizerType.SpecialType):
                    {
                        int index = getIndexToChooseRandomIngridient(currentData.specialIngredients);
                        return currentData.specialIngredients[index];
                    }
            }
        }

        else {
            int index = getIndexToChooseRandomIngridient(currentData.ingredients);
            return currentData.ingredients[index];
        }
        return null;
    }

    private int getIndexToChooseRandomIngridient(List<ingredient> ingredients)
    {
        int totalRarity = 0;
        List<int> ranges = new List<int>();

        foreach (ingredient ingredient in ingredients)
        {
            totalRarity += ingredient.getRarity();
            ranges.Add(totalRarity);
        }
        int randomValue = UnityEngine.Random.Range(1, totalRarity + 1);
        for (int i = 0; i < ingredients.Count; i++)
        {
            if (randomValue <= ranges[i])
            {
                return i;
            }
        }
        return 0;
    }

    private void renderIngredient()
    {
        spriteRend.enabled = true;     
        GameObject prefab = Resources.Load<GameObject>("Prefabs/" + correspondingPlotInData.getPlantedIngredient().getSpriteName());
        GameObject instantiatedObject = Instantiate(prefab, transform.position, Quaternion.identity);
        spriteRend.sprite = instantiatedObject.GetComponent<SpriteRenderer>().sprite;
        Destroy(instantiatedObject);
    }

    private void Update()
    {
        timePassed();
    }

}
