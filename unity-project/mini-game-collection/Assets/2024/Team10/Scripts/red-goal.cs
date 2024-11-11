using MiniGameCollection;
using MiniGameCollection.Games2024.Team10;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MiniGameCollection.Games2024.Team10
{
    public class redgoal : MonoBehaviour
    {
        public GameObject miniGameScore;
        public MiniGameScoreUI scoreUI;
        public GameObject greenPlayer;
        public GameObject redPlayer;
        public GameObject puck;
        public Vector3 greenStartPOS;
        public Quaternion greenStartROT;
        public Vector3 redStartPOS;
        public Quaternion redStartROT;
        public Vector3 puckStart;
        public float countdown = 1f;
        public bool hasScored = false;
        public TextMeshProUGUI goalUI;
        // Start is called before the first frame update
        void Start()
        {
            greenStartPOS = greenPlayer.transform.position;
            greenStartROT = greenPlayer.transform.rotation;
            redStartPOS = redPlayer.transform.position;
            redStartROT = redPlayer.transform.rotation;
            puckStart = puck.transform.position;
            scoreUI = miniGameScore.GetComponent<MiniGameScoreUI>();
            scoreUI.SetPlayerScore(1, 0);
            scoreUI.SetPlayerScore(2, 0);
        }

        private void Update()
        {
            if (hasScored == true)
            {


                countdown -= 1f * Time.deltaTime;

                if (countdown <= 0f)
                {
                    greenPlayer.transform.position = greenStartPOS;
                    greenPlayer.transform.rotation = greenStartROT;
                    redPlayer.transform.position = redStartPOS;
                    redPlayer.transform.rotation = redStartROT;
                    puck.transform.position = puckStart;

                    ResetRigidbody(greenPlayer);
                    ResetRigidbody(redPlayer);
                    ResetRigidbody(puck);
                    hasScored = false;
                    countdown = 1f;
                    goalUI.text = null;

                }
            }
        }

        public void OnCollisionExit(Collision collision)
        {
            bool hasPuckTag = collision.gameObject.GetComponent<pucktag>() != null;
            if (hasPuckTag == true)
            {
                scoreUI.IncrementPlayerScore(1);
                hasScored = true;

                goalUI.text = "Green Scores!!";


            }
        }

        //This function was added based on the recommendation of AI while using ChatGPT to troubleshoot/explain solutions. It was copy/pasted from it's recommendation
        private void ResetRigidbody(GameObject obj)
        {
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }
}