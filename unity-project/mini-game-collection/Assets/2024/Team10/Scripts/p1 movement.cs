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
        public float angleDrag = 100f;



        void Start()
        {
            rigidBody = GetComponent<Rigidbody>();
            maxSpeed = new Vector3(HandleSpeed, 0, HandleSpeed);
            rigidBody.angularDrag = angleDrag;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.W))
                if (Mathf.Abs(rigidBody.velocity.x) < maxSpeed.x)
                    rigidBody.AddForce(-10, 0, 0, ForceMode.Acceleration);

            if (Input.GetKey(KeyCode.S))
                if (rigidBody.velocity.x < maxSpeed.x)
                    rigidBody.AddForce(10, 0, 0, ForceMode.Acceleration);

            if (Input.GetKey(KeyCode.A))
                if (Mathf.Abs(rigidBody.velocity.z) < maxSpeed.z)
                    rigidBody.AddForce(0, 0, -60, ForceMode.Acceleration);

            if (Input.GetKey(KeyCode.D))
                if (rigidBody.velocity.z < maxSpeed.z)
                    rigidBody.AddForce(0, 0, 60, ForceMode.Acceleration);


            if (Input.GetKey(KeyCode.Q))
            {
                
                rigidBody.AddTorque(Vector3.up * -rotationSpeed * Time.deltaTime, ForceMode.VelocityChange);
            }

            if (Input.GetKey(KeyCode.E))
            {
                
                rigidBody.AddTorque(Vector3.up * rotationSpeed * Time.deltaTime, ForceMode.VelocityChange);
            }
        }

    }
}
