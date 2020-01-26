using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Networking;

public class CategoryContainer : MonoBehaviour
{
    public string categoryName = "";

    public GameStateManager gameStateManager;
    public List<SoundRecording> soundRecordings = new List<SoundRecording>();
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SoundRecording"))
        {
            SoundRecording soundRecording =  (SoundRecording)other.gameObject.GetComponent("SoundRecording");
            soundRecordings.Add(soundRecording);
        }
        gameStateManager.SendUpdateToServer();
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SoundRecording"))
        {
            SoundRecording soundRecording =  (SoundRecording)other.gameObject.GetComponent("SoundRecording");
            soundRecordings.Remove(soundRecording);
        }
        gameStateManager.SendUpdateToServer();
    }
}