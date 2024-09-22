using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tabButton : MonoBehaviour
{
    public string id;
    public GameObject tabManager;
    private void OnMouseDown()
    {
        tabManager.GetComponent<tabManager>().changeTab(id);
    }
}
