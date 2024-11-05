using MiniGameCollection.Games2024.Team00;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redgoal : MonoBehaviour
{
    public int redScore = 0;
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Puck"))
        {
            redScore++;
        }
    }
}
