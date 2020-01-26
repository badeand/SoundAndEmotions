using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Platform;

public class Player : MonoBehaviour
{

    public int score;

    public static Player Instance;

    
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
        
    }

    public void AddScore(int amount) {
    }
}
