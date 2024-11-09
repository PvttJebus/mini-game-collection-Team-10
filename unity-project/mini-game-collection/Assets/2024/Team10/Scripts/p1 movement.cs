using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MiniGameCollection.Games2024.Team10
{
    // script code

public class p1movement : MonoBehaviour
{
        private Rigidbody rigidBody;
        public float HandleSpeed = 14f;
        private Vector3 maxSpeed;
        public float rotationSpeed = 1f;
        public float angleDrag = 1f;
        public float dashSpeed = 10f;
        public float dashMultiplyer = 1f;
        public float dashDuration = 0f;
        public float dashUses = 3f;
        public Renderer playerRender;
        public Color originalGreen;

        //float moveX = ArcadeInput.Player1.AxisX;
        //bool moveDown = false;
        //bool moveLeft = false;
        //bool moveRight = false;
        //bool beamButton = false;
        //bool dashButton = false;


        void Start()
        {
            rigidBody = GetComponent<Rigidbody>();
            maxSpeed = new Vector3(HandleSpeed, 0, HandleSpeed);
            rigidBody.angularDrag = angleDrag;
            //playerRender = GetComponent<Renderer>();
            originalGreen = playerRender.material.color;
        }

        // Update is called once per frame
        void Update()
        {
            float xForceAdjustments = 25f;
            float zForceAdjustments = 25f;
            maxSpeed = new Vector3(HandleSpeed, 0, HandleSpeed);
            if (Input.GetKey(KeyCode.A))
                if (Mathf.Abs(rigidBody.velocity.x) < maxSpeed.x)
                    rigidBody.AddForce(-xForceAdjustments * dashMultiplyer, 0, 0, ForceMode.Acceleration);

            if (Input.GetKey(KeyCode.D))
                if (rigidBody.velocity.x < maxSpeed.x)
                    rigidBody.AddForce(xForceAdjustments * dashMultiplyer, 0, 0, ForceMode.Acceleration);

            if (Input.GetKey(KeyCode.S))
                if (Mathf.Abs(rigidBody.velocity.z) < maxSpeed.z)
                    rigidBody.AddForce(0, 0, -zForceAdjustments * dashMultiplyer, ForceMode.Acceleration);

            if (Input.GetKey(KeyCode.W))
                if (rigidBody.velocity.z < maxSpeed.z)
                    rigidBody.AddForce(0, 0, zForceAdjustments * dashMultiplyer, ForceMode.Acceleration);


            //if (Input.GetKey(KeyCode.Q))
            //{
                
            //    rigidBody.AddTorque(Vector3.up * -rotationSpeed * Time.deltaTime, ForceMode.VelocityChange);
            //}

            //if (Input.GetKey(KeyCode.E))
            //{
                
            //    rigidBody.AddTorque(Vector3.up * rotationSpeed * Time.deltaTime, ForceMode.VelocityChange);
            //}

            if (Input.GetKey(KeyCode.E))
            {
                if (dashUses > 0f && dashDuration < 0f)
                {
                    dashUses--;
                    dashMultiplyer = dashSpeed;                   
                    dashDuration = 5f;
                    playerRender.material.color = Color.blue;
                    
                }
            }

            if (dashDuration >= 0f)
            {
                dashDuration -= 1f * Time.deltaTime;
            }
            if (dashDuration < 0f)
            {
                dashMultiplyer = 1f;
                playerRender.material.color = originalGreen;
                
            }

        }

    }
}
