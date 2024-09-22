using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class sceneButton : MonoBehaviour, IPointerClickHandler
{
    //public Text seedText;
    public int sceneID;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

    }
    private void OnMouseDown()
    {
        if (audioSource != null){
            audioSource.Stop();
            audioSource.Play();
        }
        changeScene();


    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (audioSource != null){
            audioSource.Stop();
            audioSource.Play();
        }
        changeScene();
    }




    private void changeScene()
    {
        SaveSystem.Save();

        //GameObject.Find("onLoad").GetComponent<onGameLoad>().setSceneID(sceneID);
        //SceneManager.LoadScene(sceneID);
        GameObject adManager = GameObject.Find("adManager");
        try
        {
            adManager.GetComponent<adManager>().ShowInterstitialAdAndChangeScene(sceneID);
        }
        catch
        {
            SceneManager.LoadScene(sceneID);
        }
        //adManager.changeScene(sceneID);
        //SceneManager.LoadScene(sceneID);
    }
}
