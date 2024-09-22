using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class browseButton : MonoBehaviour
{
    public string buttonDirection;
    public GameObject potionsTabManager;

    private void OnMouseDown()
    {
        potionsTabManager.GetComponent<potionsTab>().updatePage(buttonDirection);
    }
}
