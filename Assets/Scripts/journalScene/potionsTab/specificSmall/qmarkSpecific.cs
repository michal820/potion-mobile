using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class qmarkSpecific : MonoBehaviour
{
    public int qmarkId;
    public GameObject hintWindowManager;

    private void OnMouseDown()
    {
        hintWindowManager.GetComponent<hintManager>().toggleHintWindowOn(qmarkId);
    }
}
