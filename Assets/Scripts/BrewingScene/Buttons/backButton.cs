using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backButton : MonoBehaviour
{
    public int sceneID;
    private void OnMouseDown()
    {
        ingredient[] selectedIngredients = brewingSlotsManager.selectedIngredients;
        for (int i = 0; i < 3; i++)
        {
            if (selectedIngredients[i] != null)
            {
                int j = selectedIngredients[i].getAmountOwned();
                selectedIngredients[i].setAmountOwned(j + 1);
            }
        }

        SaveSystem.Save();
        SceneManager.LoadScene(sceneID);
    }
}
