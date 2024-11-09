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
        float xForceAdjustments = 25f;
        float zForceAdjustments = 25f;

        //Rotation
        Vector3 movementDirect = Vector3.zero;


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
            PlayerMovement();
            PlayerDash();
           

        }


        public void PlayerMovement()
        {
            if (ArcadeInput.Player1.Left.Pressed || ArcadeInput.Player1.Left.Down)
            {
                if (Mathf.Abs(rigidBody.velocity.x) < maxSpeed.x)
                    rigidBody.AddForce(-xForceAdjustments * dashMultiplyer, 0, 0, ForceMode.Acceleration);

                movementDirect.z += 1f;
            }

            if (ArcadeInput.Player1.Right.Pressed || ArcadeInput.Player1.Right.Down)
            {
                if (rigidBody.velocity.x < maxSpeed.x)
                    rigidBody.AddForce(xForceAdjustments * dashMultiplyer, 0, 0, ForceMode.Acceleration);
                movementDirect.z -= 1f;
            }

            if (ArcadeInput.Player1.Down.Pressed || ArcadeInput.Player1.Right.Down)
            {
                if (Mathf.Abs(rigidBody.velocity.z) < maxSpeed.z)
                    rigidBody.AddForce(0, 0, -zForceAdjustments * dashMultiplyer, ForceMode.Acceleration);

                movementDirect.x -= 1f;
            }
            if (ArcadeInput.Player1.Up.Pressed || ArcadeInput.Player1.Right.Down)
            {
                if (rigidBody.velocity.z < maxSpeed.z)
                    rigidBody.AddForce(0, 0, zForceAdjustments * dashMultiplyer, ForceMode.Acceleration);
                movementDirect.x += 1f;
            }


            if (movementDirect != Vector3.zero)
            {
                movementDirect.Normalize();
                movementDirect.y = 0f;

                Quaternion targetRotation = Quaternion.LookRotation(movementDirect);

                float rotationSpeed = 90f;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            }
        }

        public void PlayerDash()
        {
            if (ArcadeInput.Player1.Action1.Pressed || Input.GetKeyDown(KeyCode.Q))
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