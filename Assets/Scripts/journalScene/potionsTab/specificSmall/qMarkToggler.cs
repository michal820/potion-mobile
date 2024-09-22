using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class qMarkToggler : MonoBehaviour
{
    private bool toggler;
    public GameObject qMarkManager;
    private void Start()
    {
        toggler = false;
    }
    private void OnMouseDown()
    {
        toggler = !toggler;
        qMarkManager.GetComponent<hintManager>().toggleQMarks(toggler);
    }

}
