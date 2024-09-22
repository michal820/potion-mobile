using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ingredientTabManager : MonoBehaviour
{
    public GameObject flowerPreviewsParent;
    public GameObject cropPreviewsParent;
    public GameObject greenPreviewsParent;
    public GameObject bugPreviewsParent;
    public GameObject rockPreviewsParent;
    public GameObject organPreviewsParent;
    public GameObject specialPreviewsParent;

    private List<GameObject> flowerPreviews;
    private List<GameObject> cropPreviews;
    private List<GameObject> greenPreviews;
    private List<GameObject> bugPreviews;
    private List<GameObject> rockPreviews;
    private List<GameObject> organPreviews;
    private List<GameObject> specialPreviews;

    private int flowerIterator;
    private int cropIterator;
    private int greenIterator;
    private int bugIterator;
    private int rockIterator;
    private int organIterator;
    private int specialIterator;

    public GameObject nameText;
    public GameObject growTimeText;
    public GameObject sellPriceText;
    public GameObject rarityText;
    public GameObject spritePreview;
    public GameObject previewOutline;
    public GameObject previewBackground;

    private void Start()
    {
        flowerIterator = 0;
        cropIterator = 0;
        greenIterator = 0;
        bugIterator = 0;
        rockIterator = 0;
        organIterator = 0;
        specialIterator = 0;

        initializePreviewLists();
        fillPreviews();
        displayNoIngredient();

    }

    private void initializePreviewLists()
    {
        flowerPreviews = new List<GameObject>();
        cropPreviews = new List<GameObject>();
        greenPreviews = new List<GameObject>();
        bugPreviews = new List<GameObject>();
        rockPreviews = new List<GameObject>();
        organPreviews = new List<GameObject>();
        specialPreviews = new List<GameObject>();

        foreach (Transform childTransform in flowerPreviewsParent.transform)
        {
            flowerPreviews.Add(childTransform.gameObject);
            childTransform.gameObject.SetActive(false);
        }
        foreach (Transform childTransform in cropPreviewsParent.transform)
        {
            cropPreviews.Add(childTransform.gameObject);
            childTransform.gameObject.SetActive(false);
        }
        foreach (Transform childTransform in greenPreviewsParent.transform)
        {
            greenPreviews.Add(childTransform.gameObject);
            childTransform.gameObject.SetActive(false);
        }
        foreach (Transform childTransform in bugPreviewsParent.transform)
        {
            bugPreviews.Add(childTransform.gameObject);
            childTransform.gameObject.SetActive(false);
        }
        foreach (Transform childTransform in rockPreviewsParent.transform)
        {
            rockPreviews.Add(childTransform.gameObject);
            childTransform.gameObject.SetActive(false);
        }
        foreach (Transform childTransform in organPreviewsParent.transform)
        {
            organPreviews.Add(childTransform.gameObject);
            childTransform.gameObject.SetActive(false);
        }
        foreach (Transform childTransform in specialPreviewsParent.transform)
        {
            specialPreviews.Add(childTransform.gameObject);
            childTransform.gameObject.SetActive(false);
        }
    }
    private void fillPreviews()
    {
        foreach(ingredient i in currentData.ingredients)
        {         
            switch (i.getType())
            {
                case "flower":
                    if (i.getIsUnlocked())
                    {
                        flowerPreviews[flowerIterator].SetActive(true);
                        GameObject ingredientPrefab = Resources.Load<GameObject>("Prefabs/" + i.getSpriteName());
                        flowerPreviews[flowerIterator].GetComponent<Image>().sprite = ingredientPrefab.GetComponent<SpriteRenderer>().sprite;
                    }
                    
                    flowerIterator++;
                    break;
                case "crop":
                    if (i.getIsUnlocked())
                    {
                        cropPreviews[cropIterator].SetActive(true);
                        GameObject ingredientPrefab = Resources.Load<GameObject>("Prefabs/" + i.getSpriteName());
                        cropPreviews[cropIterator].GetComponent<Image>().sprite = ingredientPrefab.GetComponent<SpriteRenderer>().sprite;
                    }
                    cropIterator++;
                    break;
                case "green":
                    if (i.getIsUnlocked())
                    {
                        greenPreviews[greenIterator].SetActive(true);
                        GameObject ingredientPrefab = Resources.Load<GameObject>("Prefabs/" + i.getSpriteName());
                        greenPreviews[greenIterator].GetComponent<Image>().sprite = ingredientPrefab.GetComponent<SpriteRenderer>().sprite;
                    }
                    greenIterator++;
                    break;
                case "bug":
                    if (i.getIsUnlocked())
                    {
                        bugPreviews[bugIterator].SetActive(true);
                        GameObject ingredientPrefab = Resources.Load<GameObject>("Prefabs/" + i.getSpriteName());
                        bugPreviews[bugIterator].GetComponent<Image>().sprite = ingredientPrefab.GetComponent<SpriteRenderer>().sprite;
                    }
                    bugIterator++;
                    break;
                case "rock":
                    if (i.getIsUnlocked())
                    {
                        rockPreviews[rockIterator].SetActive(true);
                        GameObject ingredientPrefab = Resources.Load<GameObject>("Prefabs/" + i.getSpriteName());
                        rockPreviews[rockIterator].GetComponent<Image>().sprite = ingredientPrefab.GetComponent<SpriteRenderer>().sprite;
                    }
                    rockIterator++;
                    break;
                case "organ":
                    if (i.getIsUnlocked())
                    {
                        organPreviews[organIterator].SetActive(true);
                        GameObject ingredientPrefab = Resources.Load<GameObject>("Prefabs/" + i.getSpriteName());
                        organPreviews[organIterator].GetComponent<Image>().sprite = ingredientPrefab.GetComponent<SpriteRenderer>().sprite;
                    }
                    organIterator++;
                    break;
                case "special":
                    if (i.getIsUnlocked())
                    {
                        specialPreviews[specialIterator].SetActive(true);
                        GameObject ingredientPrefab = Resources.Load<GameObject>("Prefabs/" + i.getSpriteName());
                        specialPreviews[specialIterator].GetComponent<Image>().sprite = ingredientPrefab.GetComponent<SpriteRenderer>().sprite;
                    }
                    specialIterator++;
                    break;
            }
           
        }
    }

    public void clickedInventorySlot()
    {
        string spriteName = this.gameObject.GetComponent<Image>().sprite.name;
        ingredient clickedIngredient = null;
        foreach (ingredient i in currentData.ingredients)
        {
            if (i.getIngredientBySpriteName(spriteName) != null)
            {
                clickedIngredient = i;
                break;
            }
        }

        if (clickedIngredient != null)
        {
            displayIngredientDetails(clickedIngredient);
        }
        else
        {
            displayNoIngredient();
        }
    }

    public void displayNoIngredient()
    {
        nameText.GetComponent<Text>().text = "";
        growTimeText.GetComponent<Text>().text = "";
        sellPriceText.GetComponent<Text>().text = "";
        rarityText.GetComponent<Text>().text = "";
        spritePreview.GetComponent<SpriteRenderer>().sprite = null;

        string hexColor = "#25262600";
        Color color;
        ColorUtility.TryParseHtmlString(hexColor, out color);
        previewBackground.GetComponent<SpriteRenderer>().color = color;
    

        hexColor = "#252626";        
        ColorUtility.TryParseHtmlString(hexColor, out color);
        previewOutline.GetComponent<SpriteRenderer>().color = color;
    }
    public void displayIngredientDetails(ingredient i)
    {
        nameText.GetComponent<Text>().text = i.getName();
        growTimeText.GetComponent<Text>().text = ""+i.getGrowTime()+ " hrs";
        sellPriceText.GetComponent<Text>().text = "plchldr";
        rarityText.GetComponent<Text>().text = i.getRarityString();
        GameObject ingredientPrefab = Resources.Load<GameObject>("Prefabs/" + i.getSpriteName());
        spritePreview.GetComponent<SpriteRenderer>().sprite = ingredientPrefab.GetComponent<SpriteRenderer>().sprite;

        string hexColor = i.getHexColor();
        Color color;
        ColorUtility.TryParseHtmlString(hexColor, out color);
        previewOutline.GetComponent<SpriteRenderer>().color = color;
        previewBackground.GetComponent<SpriteRenderer>().color = color;

    }
}
