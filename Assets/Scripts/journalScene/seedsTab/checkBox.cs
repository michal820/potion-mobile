using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkBox : MonoBehaviour
{
    public GameObject checkMark;
    private bool clickedOn;

   
    void Start()
    {
        clickedOn = true;
    }

    private void OnMouseDown()
    {
        if (clickedOn)
        {
            checkMark.SetActive(false);
            clickedOn = false;
        }
        else
        {
            checkMark.SetActive(true);
            clickedOn = true;
        }
        
    }
}
