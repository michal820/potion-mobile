using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class seedsTabManager : MonoBehaviour
{
    //main attempts viewcase
    public GameObject outlineTemplatePrefab;
    public GameObject ingrPreviewTemplatePrefab;
    public GameObject potionLabelPrefab;
    public GameObject parentPanel;
    private Transform parentTransform;

    public GameObject scrollAndMaskObject;

    //heights--Y
    private const float attemptHeight = 247f;
    private const float potionLabelHeight = 172.3f;
    //spacing--Y
    private const float spacingBetweenAttempts = 38.2f; //63?
    private const float spacingBetweenLabelAndAttempt = 0f;
    private const float spacingBetweenAttemptAndLabel = 40f; //144.35
    //start position (based on label position)
    private const float YStartPosition = -88.1f; //2199.6 1041f
    private const float XStartPosition = -267f;
    //Xposition--X
    private const float labelXValue = -267f;
    private const float attemptXValue = 0f;

    //sortViewcase
    public GameObject optionTemplatePrefab;
    public GameObject parentOptionPanel;
    private const float optionHeight = 159.52f;


    void Start()
    {
        //main attempts viewcase
        Vector3 startPosition = new Vector3(XStartPosition, YStartPosition, 0);
        Vector3 nextPosition = startPosition;
        parentTransform = parentPanel.GetComponent<Transform>();

        int potionCounter = 1;
        foreach (Potion p in currentData.potions)
        {
            if (p.getAttemptsAtThisPotion().Count != 0)
            {              
                nextPosition.x = labelXValue;
                GameObject newLabel = Instantiate(potionLabelPrefab, nextPosition, Quaternion.identity);
                newLabel.GetComponent<Text>().text = "potion " + potionCounter + ":";
                newLabel.transform.SetParent(parentTransform, false);

                nextPosition.y -= (potionLabelHeight+spacingBetweenLabelAndAttempt);
                changeParentPanelSize(potionLabelHeight + spacingBetweenLabelAndAttempt);
            }
            foreach (ingredientSet ingrSet in p.getAttemptsAtThisPotion())
            {                
                nextPosition.x = attemptXValue;
                generateAttempt(ingrSet, nextPosition);
                nextPosition.y -= (attemptHeight + spacingBetweenAttempts);
                changeParentPanelSize(attemptHeight + spacingBetweenAttempts);
            }            
            nextPosition.y += spacingBetweenAttempts;
            nextPosition.y -= spacingBetweenAttemptAndLabel;
            changeParentPanelSize(-spacingBetweenAttempts + spacingBetweenAttemptAndLabel);
            potionCounter++;
        }

        if (currentData.failedAttempts.Count != 0)
        {
            nextPosition.x = labelXValue;
            GameObject newLabel = Instantiate(potionLabelPrefab, nextPosition, Quaternion.identity);
            newLabel.GetComponent<Text>().text = "other failed attempts:";
            newLabel.transform.SetParent(parentTransform, false);

            nextPosition.x = attemptXValue;
            nextPosition.y -= (potionLabelHeight + spacingBetweenLabelAndAttempt);
            changeParentPanelSize(potionLabelHeight + spacingBetweenLabelAndAttempt);
        }
        foreach (ingredientSet ingrSet in currentData.failedAttempts)
        {
            generateAttempt(ingrSet, nextPosition);
            nextPosition.y -= (attemptHeight + spacingBetweenAttempts);
            changeParentPanelSize(attemptHeight + spacingBetweenAttempts);
        }

        scrollAndMaskObject.GetComponent<ScrollRect>().verticalNormalizedPosition = 1.0f;


        ////sort viewcase
        //startPosition = new Vector3(19.2f, 2021.2f, 0);
        //nextPosition = startPosition;
        //parentTransform = parentOptionPanel.GetComponent<Transform>();
        //for (int i = 0; i < currentData.potions.Count; i++)
        //{
        //    GameObject newOption = Instantiate(optionTemplatePrefab, nextPosition, Quaternion.identity);
        //    newOption.transform.SetParent(parentTransform, false);

        //    for (int j = 0; j < 3; j++)
        //    {
        //        string hexColor = currentData.potions[i].getRecipe()[0].getHexColor();
        //        Color color;
        //        ColorUtility.TryParseHtmlString(hexColor, out color);
        //        newOption.transform.GetChild(j + 3).GetComponent<SpriteRenderer>().color = color;
        //    }

        //    nextPosition.y -= optionHeight;
        //}

    }
    private void generateAttempt(ingredientSet ingrSet, Vector3 position)
    {

        GameObject newOutline = Instantiate(outlineTemplatePrefab, position, Quaternion.identity);
        newOutline.transform.SetParent(parentTransform, false);

        GameObject newPreview = Instantiate(ingrPreviewTemplatePrefab, position, Quaternion.identity);
        newPreview.transform.SetParent(parentTransform, false);

        for (int j = 0; j < 3; j++)
        {
            ingredient ingr = ingrSet.getThisList()[j];

            string hexColor = ingr.getHexColor();
            Color color;
            ColorUtility.TryParseHtmlString(hexColor, out color);
            newOutline.transform.GetChild(j).GetComponent<Image>().color = color;

            GameObject ingredientPrefab = Resources.Load<GameObject>("Prefabs/" + ingr.getSpriteName());
            newPreview.transform.GetChild(j).GetComponent<Image>().sprite = ingredientPrefab.GetComponent<SpriteRenderer>().sprite;
        }
        
    }
    private void changeParentPanelSize(float byHowMuch)
    {
        RectTransform rectTransform = parentPanel.GetComponent<RectTransform>();
        //rectTransform.offsetMin = new Vector2(rectTransform.offsetMin.x, rectTransform.offsetMin.y - (byHowMuch));
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, rectTransform.sizeDelta.y + byHowMuch);
    }


}
