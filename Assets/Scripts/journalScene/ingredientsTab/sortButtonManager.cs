using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sortButtonManager : MonoBehaviour
{
    public GameObject viewSortWindow;
    public GameObject viewAttemptWindow;
    private void Start()
    {
        viewSortWindow.SetActive(false);
        viewAttemptWindow.SetActive(true);
    }

    public  void sortWasClicked(bool on)
    {
        if (on)
        {
            viewSortWindow.SetActive(true);
            viewAttemptWindow.SetActive(false);
        }
        if (!on)
        {
            viewSortWindow.SetActive(false);
            viewAttemptWindow.SetActive(true);
        }
    }
}
