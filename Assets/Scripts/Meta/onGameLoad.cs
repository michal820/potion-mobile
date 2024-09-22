using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-1)]
public class onGameLoad : MonoBehaviour
{
    public static onGameLoad Instance;

    public void Awake()
    {
        if (FindObjectsOfType<onGameLoad>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
        SaveSystem.Load();
    }

    void OnApplicationQuit()
    {
        SaveSystem.Save();
    }


}
