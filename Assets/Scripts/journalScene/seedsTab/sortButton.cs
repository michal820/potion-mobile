using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sortButton : MonoBehaviour
{
    public GameObject sortButtonManagerObj;
    public bool onOrOff;

    private void OnMouseDown()
    {
        sortButtonManagerObj.GetComponent<sortButtonManager>().sortWasClicked(onOrOff);
    }
}
