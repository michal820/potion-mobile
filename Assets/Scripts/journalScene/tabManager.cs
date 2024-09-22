using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tabManager : MonoBehaviour
{
    public GameObject potionsTab;
    public GameObject ingredientsTab;
    public GameObject seedsTab;
    void Start()
    {
        ingredientsTab.SetActive(false);
        seedsTab.SetActive(false);
    }
    public void changeTab(string id)
    {
        if(id == "potions")
        {
            potionsTab.SetActive(true);
            ingredientsTab.SetActive(false);
            seedsTab.SetActive(false);
        }
        if (id == "ingredients")
        {
            potionsTab.SetActive(false);
            ingredientsTab.SetActive(true);
            seedsTab.SetActive(false);
        }
        if(id == "seeds")
        {
            potionsTab.SetActive(false);
            ingredientsTab.SetActive(false);
            seedsTab.SetActive(true);
        }
    }

}
