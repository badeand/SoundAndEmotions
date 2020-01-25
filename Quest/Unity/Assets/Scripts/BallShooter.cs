using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Platform;

public class BallShooter : MonoBehaviour
{

    public Transform ballSpawnPos;
    public GameObject ballPrefab;
    public float startForce;

    /*
    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            ShootBall();
        }
    }
    */

    public void ShootBall()
    {
        /*
        GameObject ball = Instantiate(ballPrefab, ballSpawnPos.position, ballSpawnPos.transform.rotation);
        ball.GetComponent<Rigidbody>().AddForce(ball.transform.up * startForce, ForceMode.Impulse);
        Destroy(ball, 5.0f);
        */
    }


}
