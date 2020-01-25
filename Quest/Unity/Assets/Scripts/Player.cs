using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Platform;
using TMPro;

public class Player : MonoBehaviour
{

    public int score;

    public static Player Instance;
    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Core.AsyncInitialize();
        Entitlements.IsUserEntitledToApplication().OnComplete(OnUserEntiteledToApplication);
    }

    private void OnUserEntiteledToApplication(Message msg)
    {
        /*
        if (msg.IsError) {
            UnityEngine.Application.Quit();
        }
        */
    }

    public void AddScore(int amount) {
        score += amount;
        scoreText.text = score.ToString();
    }
}
