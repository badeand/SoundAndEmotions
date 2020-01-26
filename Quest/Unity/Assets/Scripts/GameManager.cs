using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Platform;


public class GameManager : MonoBehaviour
{

    public float roundDuration = 30.0f;
    private float curRoundTime;
    private bool roundInProgress;

    public float ballShootFrequency;
    private float lastBallShootTime;

    public BallShooter ballShooter;

    public GameObject newRoundButton;


    public void BeginNewRound()
    {
        
    }

    
}
