using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioMaster : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(this);
    }
    public void playSoundEffect(AudioSource audioSource)
    {
        if (audioSource != null)
        {
            audioSource.Stop();
            audioSource.Play();
        }
    }
}
