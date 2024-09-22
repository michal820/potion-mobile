using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class brewOrganizeInventory : MonoBehaviour
{
    public Transform parent;
    public Text textPrefab;
    public Sprite outline;
    public static List<GameObject> inventorySlots;


    public void Start()
    {
        SaveSystem.Load(); 

        inventorySlots = new List<GameObject>();
        initializeSlotList();
        updateSlotList();
    }

    private void initializeSlotList()
    {
        int numChildren = parent.childCount;
        for (int i = 0; i < numChildren; i++)
        {
            GameObject child = parent.GetChild(i).gameObject;
            int numGrandchildren = child.transform.childCount;

            for (int j = 0; j < numGrandchildren; j++)
            {
                GameObject grandChild = child.transform.GetChild(j).gameObject;
                inventorySlots.Add(grandChild);
            }

        }
    }

    public void updateSlotList()
    {
        foreach (GameObject i in inventorySlots)
        {
            Transform inventorySlotTransform = i.transform;
            for (int j = inventorySlotTransform.childCount - 1; j >= 0; j--)
            {
                Transform child = inventorySlotTransform.GetChild(j);
                Destroy(child.gameObject);
            }
            i.GetComponent<Image>().sprite = outline;
        }

        List<GameObject> slots = inventorySlots;

        int counter = 0;
        foreach (ingredient i in currentData.ingredients){
            if (i.getAmountOwned() != 0)
            {
                GameObject prefab = Resources.Load<GameObject>("Prefabs/" + i.getSpriteName());
                GameObject instantiatedObject = Instantiate(prefab, transform.position, Quaternion.identity);
                slots[counter].GetComponent<Image>().sprite = instantiatedObject.GetComponent<SpriteRenderer>().sprite;
                Destroy(instantiatedObject);

                Text amountWritten = Instantiate(textPrefab, slots[counter].gameObject.transform);
                amountWritten.transform.SetParent(slots[counter].transform);

                amountWritten.text = i.getAmountOwned().ToString();

                counter++;   
            }
           
        }

    }




}
