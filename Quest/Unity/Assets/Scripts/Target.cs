using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int scoreToGive;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball")) {
            // add score to player
            Player.Instance.AddScore(scoreToGive);
            Destroy(collision.gameObject, 1.0f);
        }
    }
}
