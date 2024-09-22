using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Purchasing;

public class storeItemManager : MonoBehaviour
{
    public GameObject hintPrice;
    public GameObject landPrice;
    public GameObject toolPrice;

    public GameObject hintSeedLogo;
    public GameObject landSeedLogo;
    public GameObject toolSeedLogo;

    public GameObject hintBox;
    public GameObject landBox;
    public GameObject toolBox;

    public GameObject hintMaxedText;
    public GameObject landMaxedText;
    public GameObject toolMaxedText;

    public GameObject seedsText;

    private void Start()
    {
        updateHints();
        updateLand();
        updateTools();
        
    }
    public void updateHints()
    {
        if (currentData.hintsOwned == 5)
        {
            hintPrice.SetActive(false);
            hintSeedLogo.SetActive(false);
            hintBox.GetComponent<Image>().raycastTarget = false;
            hintMaxedText.SetActive(true);
        }
        else
        {
            string priceString = "";
            switch (currentData.hintsOwned)
            {
                case (0):
                    {
                        priceString = "1k";
                        break;
                    }
                case (1):
                    {
                        priceString = "10k";
                        break;
                    }
                case (2):
                    {
                        priceString = "100k";
                        break;
                    }
                case (3):
                    {
                        priceString = "500k";
                        break;
                    }

                case (4):
                    {
                        priceString = "1m";
                        break;
                    }
            }
            hintPrice.GetComponent<Text>().text = priceString;
            hintMaxedText.SetActive(false);
        }
    }
    public void updateLand()
    {
        if (currentData.landOwned == 3)
        {
            landPrice.SetActive(false);
            landSeedLogo.SetActive(false);
            landMaxedText.SetActive(true);
            landBox.GetComponent<Image>().raycastTarget = false;
        }

        else
        {
            string priceString;
            priceString = "";
            switch (currentData.landOwned)
            {
                case (0):
                    {
                        priceString = "100k";
                        break;
                    }
                case (1):
                    {
                        priceString = "500k";
                        break;
                    }
                case (2):
                    {
                        priceString = "1m";
                        break;
                    }
            }
            landPrice.GetComponent<Text>().text = priceString;
            landMaxedText.SetActive(false);
        }
    }
    public void updateTools()
    {
        if (currentData.toolsOwned == 3)
        {
            toolPrice.SetActive(false);
            toolSeedLogo.SetActive(false);
            toolMaxedText.SetActive(true);
            toolBox.GetComponent<Image>().raycastTarget = false;
        }
        else
        {
            string priceString;
            priceString = "";
            switch (currentData.toolsOwned)
            {
                case (0):
                    {
                        priceString = "100k";
                        break;
                    }
                case (1):
                    {
                        priceString = "500k";
                        break;
                    }
                case (2):
                    {
                        priceString = "1m";
                        break;
                    }
            }
            toolPrice.GetComponent<Text>().text = priceString;
            toolMaxedText.SetActive(false);

        }
    }

    public void boughtSeeds(Product product)
    {
        Debug.Log("clicking button");
        currentData.seedsLeft += (int) product.definition.payout.quantity;
        seedsText.GetComponent<Text>().text = "seeds: " + currentData.seedsLeft;
    }
}
