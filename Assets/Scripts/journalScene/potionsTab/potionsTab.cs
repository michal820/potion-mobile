using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class potionsTab : MonoBehaviour
{
    public GameObject pagesText;
    public GameObject questionmarkPreviewPlaceholder;
    public GameObject spritePreview;
    public GameObject name;

    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;

    public GameObject outline1;
    public GameObject outline2;
    public GameObject outline3;

    public GameObject hintManager; //notify if page turned
    int pageNumber;
    
    void Start()
    {
        pageNumber = 1;
        updatePage("none");

    }

    public void updatePage(string direction)
    {
        GameObject[] outlines = { outline1, outline2, outline3 };
        GameObject[] slots = { slot1, slot2, slot3 };
        if (direction == "right")
        {
            if (pageNumber == 13)
            {
                pageNumber = 1; 
            }
            else
            {
                pageNumber++;
            }
        }
        if (direction == "left")
        {
            if (pageNumber == 1)
            {
                pageNumber = 13;
            }
            else
            {
                pageNumber--;
            }
        }
        pagesText.GetComponent<Text>().text = pageNumber + "/" + (currentData.potions.Count-1) ;

        if (currentData.potions[pageNumber-1].getAmountOwned() !=0)
        {
            //set preview
            spritePreview.SetActive(true);
            questionmarkPreviewPlaceholder.SetActive(false);
            Sprite spriteToLoad = getSprite();
            spritePreview.GetComponent<SpriteRenderer>().sprite = spriteToLoad;

            //set recipe
            slot1.SetActive(true);
            slot2.SetActive(true);
            slot3.SetActive(true);
            ingredient[] recipe = currentData.potions[pageNumber - 1].getRecipe();
            Sprite ingredient = Resources.Load<GameObject>("Prefabs/" + recipe[0].getSpriteName()).GetComponent<SpriteRenderer>().sprite;
            slot1.GetComponent<SpriteRenderer>().sprite = ingredient;

            ingredient = Resources.Load<GameObject>("Prefabs/" + recipe[1].getSpriteName()).GetComponent<SpriteRenderer>().sprite;
            slot2.GetComponent<SpriteRenderer>().sprite = ingredient;

            ingredient = Resources.Load<GameObject>("Prefabs/" + recipe[2].getSpriteName()).GetComponent<SpriteRenderer>().sprite;
            slot3.GetComponent<SpriteRenderer>().sprite = ingredient;

            string colorHex = "#6C2626";
            Color color;
            ColorUtility.TryParseHtmlString(colorHex, out color);
            outline1.GetComponent<SpriteRenderer>().color = color;
            outline2.GetComponent<SpriteRenderer>().color = color;
            outline3.GetComponent<SpriteRenderer>().color = color;

            //set name


        }
        else
        {
            //set preview
            spritePreview.SetActive(false);
            questionmarkPreviewPlaceholder.SetActive(true);

            //set recipe
            slot1.SetActive(false);
            slot2.SetActive(false);
            slot3.SetActive(false);
                //set hints (acutal ingridient)
            for(int i =0; i<3; i++)
            {
                ingredient hint = currentData.potions[pageNumber - 1].getHints()[i];
                if (hint != null)
                {
                    slots[i].SetActive(true);
                    GameObject ingredientPrefab = Resources.Load<GameObject>("Prefabs/" + hint.getSpriteName());
                    slots[i].GetComponent<SpriteRenderer>().sprite = ingredientPrefab.GetComponent<SpriteRenderer>().sprite;
                }
            }
                //set colors (categories  --  color coded)
            ingredient[] recipe = currentData.potions[pageNumber - 1].getRecipe();
            for(int i = 0; i < recipe.Length; i++)
            {
                string colorHex = recipe[i].getHexColor();              
                Color color;
                ColorUtility.TryParseHtmlString(colorHex, out color);
                outlines[i].GetComponent<SpriteRenderer>().color = color;
            }
        }

        hintManager.GetComponent<hintManager>().updateQMarks();
    }

    private Sprite getSprite()
    {
        GameObject potionPrefab = Resources.Load<GameObject>("Prefabs/" + currentData.potions[pageNumber - 1].getSpriteName());
        return potionPrefab.GetComponent<SpriteRenderer>().sprite;

    }

    public int getPageNumber()
    {
        return pageNumber;
    }
}
//Assets / Resources / Prefabs / Potions_0.prefab