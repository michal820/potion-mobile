using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class potionInventory : MonoBehaviour
{
    public Transform parentTransform;
    private List<GameObject> potionSlots;
    public Sprite questionMark;

    private void Start()
    {

        potionSlots = new List<GameObject>();
        for (int i = 0; i < parentTransform.childCount; i++)
        {
            Transform childTransform = parentTransform.GetChild(i);
            GameObject childGameObject = childTransform.gameObject;
            potionSlots.Add(childGameObject);
            potionSlots[i].GetComponent<Image>().sprite = questionMark;
        }
        organizeInventory();

    }

    private void organizeInventory()
    {
        if (currentData.potions != null)
        {
            for (int i = 0; i < currentData.potions.Count; i++)
            {
                if (currentData.potions[i].getAmountOwned() != 0)
                {
                    GameObject prefab = Resources.Load<GameObject>("Prefabs/" + currentData.potions[i].getSpriteName());
                    GameObject instantiatedObject = Instantiate(prefab, transform.position, Quaternion.identity);
                    potionSlots[i].GetComponent<Image>().sprite = instantiatedObject.GetComponent<SpriteRenderer>().sprite;
                    Destroy(instantiatedObject);
                }
            }
        }
    }
}
