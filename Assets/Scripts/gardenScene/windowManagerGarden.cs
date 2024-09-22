using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class windowManagerGarden : MonoBehaviour
{
    public GameObject selectionManagerObj;

    public GameObject windowCanvas;
    public GameObject greyArrow;
    public GameObject greyGears;
    public GameObject seeds;

    public GameObject shopPromptText;

    public GameObject land1;
    public GameObject land2;
    public GameObject land3;

    public GameObject tool1;
    public GameObject tool2;
    public GameObject tool3;

    private int fertilizersOwned;
    public GameObject contentPanelParent;

    public void toggleWindow(bool isOn)
    {
        windowCanvas.SetActive(isOn);
        if (isOn)
        {
            greyArrow.SetActive(true);
            greyGears.SetActive(true);
            foreach (Transform childSeed in seeds.GetComponent<Transform>())
            {
                childSeed.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        else
        {
            greyArrow.SetActive(false);
            greyGears.SetActive(false);
            //selectionManagerObj.GetComponent<selectionManager>().resetFertilizers();
            foreach (Transform childSeed in seeds.GetComponent<Transform>())
            {
                childSeed.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }

    private void Start()
    {
        toggleWindow(false);

        fertilizersOwned = 0;
        foreach(Fertilizer f in currentData.fertilizers)
        {
            fertilizersOwned += f.getAmount();
        }
        if (currentData.landOwned == 0 && currentData.toolsOwned == 0 && fertilizersOwned == 0)
        {
            land1.SetActive(false);
            land2.SetActive(false);
            land3.SetActive(false);
            tool1.SetActive(false);
            tool2.SetActive(false);
            tool3.SetActive(false);
            shopPromptText.SetActive(true);
        }
        else
        {
            shopPromptText.SetActive(false);
            displayLand();
            displayTools();
            displayFertilizers();
        }       
    }
    
    private void displayLand()
    {
        if (currentData.landOwned  == 0)
        {
            land1.SetActive(false);
            land2.SetActive(false);
            land3.SetActive(false);
        }
        else if (currentData.landOwned == 1) //aka 2 plots owned... (since the first one you start with is "0")
        {
            land1.SetActive(true);
            land2.SetActive(true);
            land3.SetActive(false);
        }
        else if (currentData.landOwned  == 2) //aka 3 plots owned
        {
            land1.SetActive(true);
            land2.SetActive(true);
            land3.SetActive(true);
        }
    }

    private void displayTools()
    {
        if(currentData.toolsOwned == 0)
        {
            tool1.SetActive(false);
            tool2.SetActive(false);
            tool3.SetActive(false);
        }
        else if (currentData.toolsOwned == 1)
        {
            tool1.SetActive(true);
            tool2.SetActive(false);
            tool3.SetActive(false);
        }
        else if (currentData.toolsOwned == 2)
        {
            tool1.SetActive(true);
            tool2.SetActive(true);
            tool3.SetActive(false);
        }
        else
        {
            tool1.SetActive(true);
            tool2.SetActive(true);
            tool3.SetActive(true);
        }
    }


    private const float yPos = -57.3f;
    private const float startingXPos = 5f;
    private const float bagWidth = 3.8f;
    private const float bagSpacing = 268f;

    private void displayFertilizers()
    {
        Vector3 startPosition = new Vector3(startingXPos, yPos, 0);
        Vector3 nextPosition = startPosition;

        //add the starting x position to the size of the content panel
        RectTransform rectTransform = contentPanelParent.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x + startingXPos + 21f, rectTransform.sizeDelta.y);

        foreach (Fertilizer f in currentData.fertilizers)
        {
            if (f.getAmount() != 0)
            {
                //instantiate object at the next position
                GameObject prefab = Resources.Load<GameObject>("Prefabs/" + f.getSpriteName());
                GameObject instantiatedObject = Instantiate(prefab, nextPosition, Quaternion.identity);
                instantiatedObject.GetComponent<Transform>().SetParent(contentPanelParent.GetComponent<Transform>(), false);
                instantiatedObject.AddComponent<fertilizerAttribute>();
                instantiatedObject.GetComponent<fertilizerAttribute>().fert = f;

                //notify selectionManager of the instantiated bag
                selectionManagerObj.GetComponent<selectionManager>().addFertilizer(instantiatedObject);

                //customize the bag                
                switch (f.getSpriteName())
                {
                    case ("SpeciesBag"):
                        string hexColor = f.getColorOrText();
                        Color color;
                        ColorUtility.TryParseHtmlString(hexColor, out color);
                        instantiatedObject.GetComponent<Transform>().GetChild(3).GetComponent<Image>().color = color;

                        instantiatedObject.GetComponent<Transform>().GetChild(5).GetComponent<Text>().text = f.getAmount().ToString();
                        break;
                    case ("RarityBag"):
                        hexColor = f.getColorOrText();
                        ColorUtility.TryParseHtmlString(hexColor, out color);
                        instantiatedObject.GetComponent<Transform>().GetChild(4).GetComponent<Image>().color = color;

                        instantiatedObject.GetComponent<Transform>().GetChild(6).GetComponent<Text>().text = f.getAmount().ToString();
                        break;
                    case ("SpeedBag"):
                        instantiatedObject.GetComponent<Transform>().GetChild(4).GetComponent<Text>().text = f.getColorOrText();
                        instantiatedObject.GetComponent<Transform>().GetChild(6).GetComponent<Text>().text = f.getAmount().ToString();
                        break;
                }
                
                //set the next position for the  next bag
                nextPosition.x += (bagWidth + bagSpacing);

                //increase size of the parent contentPanel 
                rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x + bagWidth + bagSpacing, rectTransform.sizeDelta.y);
                Debug.Log("xDelta:" + rectTransform.sizeDelta.x + bagWidth + bagSpacing);

            }
        }

    }

    public void refreshFertilizers()
    {
        foreach (Transform child in contentPanelParent.GetComponentsInChildren<Transform>())
        {
            if (child != contentPanelParent.transform)
            {
                Destroy(child.gameObject);
            }
        }

        displayFertilizers();

    }
}
