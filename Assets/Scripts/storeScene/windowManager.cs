using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class windowManager : MonoBehaviour
{
    public GameObject window; 
    private Fertilizer fert;
    private string objtype;
    private int price;
    private string priceString;

    public GameObject nameObj;
    public GameObject subNameObj;
    public GameObject descObj;
    public GameObject priceObj;

    public GameObject buyButton;
    public GameObject buyText;
    public GameObject notEnoughSeedsText;

    public GameObject seedsWallet;

    public GameObject storeItemManager;

    private List<GameObject> amounts;
    public GameObject circle1;
    public GameObject circle2;
    public GameObject circle3;
    public GameObject circle4;
    public GameObject circle5;
    

    public GameObject amountsParent;
    public GameObject buyArea;
    public GameObject windowBackground;
    

    int amountVal;


    private void Start()
    {
        amounts = new List<GameObject>();
        amounts.Add(circle1);
        amounts.Add(circle2);
        amounts.Add(circle3);
        amounts.Add(circle4);
        amounts.Add(circle5);
        seedsWallet.GetComponent<Text>().text = "seeds: " + currentData.seedsLeft;
        amountVal = 1;
        priceString = "";
        turnWindowOff();
    }

    public void updateAmountVal(int amount)
    {
        amountVal = amount;
    }

    public void turnWindowOff()
    {
        //if (fert == null)
        //{
        //    switch (objtype)
        //    {
        //        case ("hint"):
        //            {
        //                storeItemManager.GetComponent<storeItemManager>().updateHints();
        //                break;
        //            }
        //        case ("land"):
        //            {
        //                storeItemManager.GetComponent<storeItemManager>().updateLand();
        //                break;
        //            }
        //        case ("tool"):
        //            {
        //                storeItemManager.GetComponent<storeItemManager>().updateTools();
        //                break;
        //            }
        //    }
        //}
        storeItemManager.GetComponent<storeItemManager>().updateHints();
        storeItemManager.GetComponent<storeItemManager>().updateLand();
        storeItemManager.GetComponent<storeItemManager>().updateTools();

        objtype = null;
        fert = null;

        string hexColor = "#573510";
        Color color;
        ColorUtility.TryParseHtmlString(hexColor, out color);
        buyButton.GetComponent<Image>().color = color;

        hexColor = "#D4C7B3";
        ColorUtility.TryParseHtmlString(hexColor, out color);
        buyText.GetComponent<Text>().color = color;

        notEnoughSeedsText.SetActive(false);

        itemSpecific.windowOpen = false;

        amountVal = 1;
        changeSelectedAmount(circle1);

        window.SetActive(false);
    }

    public void turnFertWindowOn(FertilizerType fertType)
    {
        fert = getFertilizerByType(fertType);
        price = fert.getPrice();

        //set  name
        string name = "";
        if (fertType.ToString().Contains("Rarity"))
            name = "Rarity Fertilizer";
        else if (fertType.ToString().Contains("Speed"))
            name = "Speed Fertilizer";
        else
            name = "Species Fertilizer";
        nameObj.GetComponent<Text>().text = name;
        //set subname
        subNameObj.SetActive(true);
        string subName = "";
        int index = fert.getName().IndexOf("- ");
        if (index != -1)
            subName = fert.getName().Substring(index + 2);
        subName = subName.ToLower();
        subNameObj.GetComponent<Text>().text = subName;
        //set the rest
        descObj.GetComponent<Text>().text = fert.getDescription();
        priceObj.GetComponent<Text>().text = "buy for " + price*amountVal + " seeds?";
        ////////
        Vector3 newPosition = buyArea.GetComponent<Transform>().position;
        newPosition.x = -260.7381f;
        newPosition.y = -11;//6.944124f
        buyArea.GetComponent<Transform>().localPosition = newPosition;

        RectTransform wBTransform = windowBackground.GetComponent<RectTransform>();
        wBTransform.offsetMin = new Vector2(wBTransform.offsetMin.x, 597.75f);

        amountsParent.SetActive(true);
        ////////

        if (price*amountVal > currentData.seedsLeft)
        {
            displayNotEnough();
        }
        itemSpecific.windowOpen = true;
        window.SetActive(true);       
    }
    
    public void turnObjWindowOn(string objType)
    {
        objtype = objType;
        subNameObj.SetActive(false);

        switch (objType)
        {
            case ("hint"):
                {
                    nameObj.GetComponent<Text>().text = "hint";
                    descObj.GetComponent<Text>().text = "show the ingridient for a recipe of your choice in your journal";
                    switch (currentData.hintsOwned)
                    {
                        case (0):
                            {
                                price = 1000;
                                priceString = "1k";
                                break;                           
                            }
                        case (1):
                            {
                                price = 10000;
                                priceString = "10k";
                                break;
                            }
                        case (2):
                            {
                                price = 100000;
                                priceString = "100k";
                                break;
                            }
                        case (3):
                            {
                                price = 500000;
                                priceString = "500k";
                                break;
                            }

                        case (4):
                            {
                                price = 1000000;
                                priceString = "1m";
                                break;
                            }
                        default:
                            {
                                turnWindowOff();
                                return;
                            }
                    }
                    priceObj.GetComponent<Text>().text = "buy for " + priceString + " seeds?";
                    break;
                }
            case ("land"):
                {
                    nameObj.GetComponent<Text>().text = "land";
                    descObj.GetComponent<Text>().text = "get more land in your garden";
                    switch (currentData.landOwned)
                    {
                        case (0):
                            {
                                price = 100000;
                                priceString = "100k";
                                break;
                            }
                        case (1):
                            {
                                price = 500000;
                                priceString = "500k";
                                break;
                            }
                        case (2):
                            {
                                price = 1000000;
                                priceString = "1m";
                                break;
                            }
                        default:
                            {
                                turnWindowOff();
                                return;
                            }
                    }
                    priceObj.GetComponent<Text>().text = "buy for " + priceString + " seeds?";
                    break;
                }
            case ("tool"):
                {
                    nameObj.GetComponent<Text>().text = "tool";
                    descObj.GetComponent<Text>().text = "plant and collect multiple ingridients at once";
                    switch (currentData.toolsOwned)
                    {
                        case (0):
                            {
                                price = 100000;
                                priceString = "100k";
                                break;
                            }
                        case (1):
                            {
                                price = 500000;
                                priceString = "500k";
                                break;
                            }
                        case (2):
                            {
                                price = 1000000;
                                priceString = "1m";
                                break;
                            }
                        default:
                            {
                                turnWindowOff();
                                return;
                            }
                    }                    
                    priceObj.GetComponent<Text>().text = "buy for " + priceString + " seeds?";
                    break;
                }
        }
        ///////////
        Vector3 newPosition = buyArea.GetComponent<Transform>().position;
        newPosition.x = -260.7381f;
        newPosition.y = 182; //202.36f
        buyArea.GetComponent<Transform>().localPosition = newPosition; 

        RectTransform wBTransform = windowBackground.GetComponent<RectTransform>();
        wBTransform.offsetMin = new Vector2(wBTransform.offsetMin.x, 757.6f);

        amountsParent.SetActive(false);
        /////////////

        if (price*amountVal > currentData.seedsLeft)
        {
            displayNotEnough();
        }
        itemSpecific.windowOpen = true;
        window.SetActive(true);
    }

    public void buy()
    {
        if(fert != null)
        {
            boughtFert();
        }
        else
        {
            boughtObj();
        }
    }

    private void boughtFert()
    {
        if(currentData.seedsLeft >= price*amountVal)
        {
            fert.addAmount(amountVal);
            currentData.seedsLeft -= (price * amountVal);
            Debug.Log(fert.getName() +": " +  fert.getAmount());
            seedsWallet.GetComponent<Text>().text = "seeds: " + currentData.seedsLeft;
        }
        if (currentData.seedsLeft < price * amountVal)
        {
            displayNotEnough();
        }

    }

    private void boughtObj()
    {
        switch (objtype)
        {
            case ("hint"):
                {
                    if (currentData.seedsLeft >= price*amountVal)
                    {
                        currentData.hintsOwned += (amountVal);
                        currentData.seedsLeft -= (price * amountVal);
                    }                        
                    break;
                }
            case ("land"):
                {
                    if (currentData.seedsLeft >= price*amountVal)
                    {
                        currentData.landOwned += (amountVal);
                        currentData.seedsLeft -= (price * amountVal);
                    }
                    break;
                }
            case ("tool"):
                {
                    if (currentData.seedsLeft >= price*amountVal)
                    {
                        currentData.toolsOwned += (amountVal);
                        currentData.seedsLeft -= (price * amountVal);
                    }
                    break;
                }
        }
        seedsWallet.GetComponent<Text>().text = "seeds: " + currentData.seedsLeft; ;
        turnObjWindowOn(objtype);
    }

    private void displayNotEnough()
    {
        string hexColor = "#ADADAD";
        Color color;
        ColorUtility.TryParseHtmlString(hexColor, out color);
        buyButton.GetComponent<Image>().color = color;

        hexColor = "#525252";
        ColorUtility.TryParseHtmlString(hexColor, out color);
        buyText.GetComponent<Text>().color = color;

        notEnoughSeedsText.SetActive(true);
    }

    private void undoDisplayNotEnough()
    {
        string hexColor = "#573510";
        Color color;
        ColorUtility.TryParseHtmlString(hexColor, out color);
        buyButton.GetComponent<Image>().color = color;

        hexColor = "#D4C7B3";
        ColorUtility.TryParseHtmlString(hexColor, out color);
        buyText.GetComponent<Text>().color = color;

        notEnoughSeedsText.SetActive(false);
    }

    public void changeSelectedAmount(GameObject selectedAmount)
    {
        string hexColor = "#C0A27B";
        Color color;
        ColorUtility.TryParseHtmlString(hexColor, out color);
        selectedAmount.GetComponent<Image>().color = color;

        foreach (GameObject amount in amounts)
        {
            if(amount != selectedAmount)
            {
                hexColor = "#ECE6CE";
                ColorUtility.TryParseHtmlString(hexColor, out color);
                amount.GetComponent<Image>().color = color;
            }
        }

        priceObj.GetComponent<Text>().text = "buy for " + price * amountVal + " seeds?";


        if (amountVal*price  > currentData.seedsLeft)
        {
            displayNotEnough();
        }
        else
        {
            undoDisplayNotEnough();
        }
    }

    private Fertilizer getFertilizerByType(FertilizerType fertType)
    {
        foreach (Fertilizer f in currentData.fertilizers)
        {
            if (f.returnThisFertIfTypeMatches(fertType) != null)
            {
                return f;
            }
        }
        return null;
    }

    //private string getSeedsAmntAsString() {
    //    int seedsAmnt = currentData.seedsLeft;
    //    string seedString = "";
    //    if(currentData.seedsLeft > 1000000)
    //    {
    //        seedsAmnt = seedsAmnt / 1000000;
    //        seedString = seedsAmnt + "m";
    //    }
    //    else if (currentData.seedsLeft > 1000)
    //    {
    //        seedsAmnt = seedsAmnt / 1000;
    //        seedString = seedsAmnt + "k";
    //    }
    //    else
    //    {
    //        seedString = seedsAmnt.ToString();
    //    }
    //    return seedString;
    //}
}
