using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Platform;
using TMPro;

public class GameManager : MonoBehaviour
{

    public float roundDuration = 30.0f;
    private float curRoundTime;
    private bool roundInProgress;

    public float ballShootFrequency;
    private float lastBallShootTime;

    public BallShooter ballShooter;

    public GameObject newRoundButton;
    public TextMeshProUGUI roundTimeText;

    public void Update()
    {

        /*
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            BeginNewRound();
        }
        */

        if ( roundInProgress)
        {
            curRoundTime -= Time.deltaTime;

            roundTimeText.text = Mathf.RoundToInt(curRoundTime).ToString();

            if( Time.time - lastBallShootTime >= ballShootFrequency)
            {
                lastBallShootTime = Time.time;
                ballShooter.ShootBall();
            }

            if( curRoundTime <= 0.0f )
            {
                EndRound();
            }
        }
    }

    public void BeginNewRound()
    {
        Player.Instance.AddScore(-Player.Instance.score);
        curRoundTime = roundDuration;
        roundInProgress = true;
        newRoundButton.SetActive(false);
    }


    void EndRound() {
        roundInProgress = false;
        curRoundTime = 0.0f;
        newRoundButton.SetActive(true);
    }
}
