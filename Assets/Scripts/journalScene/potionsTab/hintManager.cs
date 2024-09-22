using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hintManager : MonoBehaviour
{
    public GameObject potionsTabObj;    //  for page number

    // manage qmarks
    public GameObject hintLogoButton;
    public GameObject XButton;
    public GameObject qMark1;
    public GameObject qMark2;
    public GameObject qMark3;
    private bool qMarksToggle;

    // manage popup
    public GameObject hintwindow;
    public GameObject hintNumberText;
    private int qmarkID;

    void Start()
    {
        hintLogoButton.SetActive(true);
        XButton.SetActive(false);
        qMark1.SetActive(false);
        qMark2.SetActive(false);
        qMark3.SetActive(false);
        qMarksToggle = false;


        hintwindow.SetActive(false);

        hintNumberText.GetComponent<Text>().text = currentData.hintsOwned+"";
    }

    public void toggleQMarks(bool on)
    {
        qMarksToggle = on;
        if (on)
        {
            hintLogoButton.SetActive(false);
            XButton.SetActive(true);
            updateQMarks();
        }
        else
        {
            hintLogoButton.SetActive(true);
            XButton.SetActive(false);
            qMark1.SetActive(false);
            qMark2.SetActive(false);
            qMark3.SetActive(false);
        }
    }

    public void updateQMarks()
    {
        if (qMarksToggle)
        {
            int potionIndex = potionsTabObj.GetComponent<potionsTab>().getPageNumber() - 1;
            ingredient[] hints = currentData.potions[potionIndex].getHints();
            if (hints[0] == null) {
                qMark1.SetActive(true);
            }
            else {
                qMark1.SetActive(false);
            }
            if (hints[1] == null) {
                qMark2.SetActive(true);
            }
            else {
                qMark2.SetActive(false);
            }
            if (hints[2] == null){
                qMark3.SetActive(true);
            }
            else {
                qMark3.SetActive(false);
            }
        }
    }


    public void toggleHintWindowOn(int qmarkID)
    {
        hintwindow.SetActive(true);
        this.qmarkID = qmarkID;
    }

    public void toggleHintWindowOff()
    {
        hintwindow.SetActive(false);

    }
    public void buyHint()
    {
        if (currentData.hintsOwned != 0)
        {
            int potionIndex = potionsTabObj.GetComponent<potionsTab>().getPageNumber() - 1;
            ingredient[] hints = currentData.potions[potionIndex].getHints();
            hints[qmarkID] = currentData.potions[potionIndex].getRecipe()[qmarkID];
            //currentData.potions[potionIndex].setHints(hints);
            toggleHintWindowOff();
            potionsTabObj.GetComponent<potionsTab>().updatePage("none");
            currentData.hintsOwned--;
            hintNumberText.GetComponent<Text>().text = currentData.hintsOwned + "";
        }        
    }
    
}
