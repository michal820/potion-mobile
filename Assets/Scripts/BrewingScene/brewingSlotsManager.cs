using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class brewingSlotsManager : MonoBehaviour
{
    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;
    public Sprite outline;
    private GameObject[] brewingSlots;
    public static ingredient[] selectedIngredients;

    void Start()
    {
        selectedIngredients = new ingredient[3] { null, null, null };
        brewingSlots = new GameObject[3] { slot1, slot2, slot3 };

    }

    public void addSelected(ingredient ingr)
    {
        
        if (ingr != null)
        {
            int index = findAvailableSlot();

            if (index < 3)
            {
                selectedIngredients[index] = ingr;
                //render ingredient
                GameObject prefab = Resources.Load<GameObject>("Prefabs/" + ingr.getSpriteName());
                GameObject instantiatedObject = Instantiate(prefab, transform.position, Quaternion.identity);
                brewingSlots[index].GetComponent<SpriteRenderer>().sprite = instantiatedObject.GetComponent<SpriteRenderer>().sprite;
                Destroy(instantiatedObject);
                //brewingSlots[index].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(ingr.getSpriteName());

                
                int currentAmount = ingr.getAmountOwned();
                ingr.setAmountOwned(currentAmount - 1);
                
                GameObject.Find("organizeInventory").GetComponent<brewOrganizeInventory>().updateSlotList();
            }
        }
    }

    private int findAvailableSlot()
    {
        for(int i = 0; i < 3; i++)
        {
            if (selectedIngredients[i] == null)
                return i;
        }
        return 3;
    }

    public void removeIngredientFromSlot(ingredient ingr, int index)
    {
        int currentAmount = ingr.getAmountOwned();
        ingr.setAmountOwned(currentAmount + 1);
        brewingSlots[index].GetComponent<SpriteRenderer>().sprite = outline;
        selectedIngredients[index] = null;
        GameObject.Find("organizeInventory").GetComponent<brewOrganizeInventory>().updateSlotList();
       
        //save data??
    }

    public ingredient[] getSelectedIngredients()
    {
        return selectedIngredients;
    }


}
