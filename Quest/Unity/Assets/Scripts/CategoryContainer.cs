using System;
using System.Collections;
using System.Text;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Networking;

public class CategoryContainer : MonoBehaviour
{
    public string categoryName = "";

    public GameStateManager gameStateManager; 

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SoundRecording"))
        {
            SoundRecording soundRecording =  (SoundRecording)other.gameObject.GetComponent("SoundRecording");
            gameStateManager.AddToPickedUpSoundRecordings(soundRecording);
        }

    }

    
}