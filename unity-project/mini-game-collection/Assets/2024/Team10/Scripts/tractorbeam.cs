using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tractorbeam : MonoBehaviour
{

    public GameObject holdLocation;
    public GameObject itemInBeam;
    public Rigidbody itemInBeamRB;
    private bool beamActivated;
    public bool isHolding;
    public int beamCooldown = 5;
    // Start is called before the first frame update
    void Start()
    {
        isHolding = false;

    }

    // Update is called once per frame
    void Update()
    {
        beamActivated = Input.GetKey(KeyCode.Space);
        TractorBeam();

        if (beamCooldown != 0f)
        {
            beamCooldown--;
        }
       

    }

    public void TractorBeam()
    {
        if (isHolding == false && beamActivated == true)
        {
            itemInBeam.gameObject.transform.position = holdLocation.transform.position;
            isHolding = true;
        }

        else if (isHolding == true && beamActivated == false)
        {
            itemInBeam.gameObject.transform.position = holdLocation.transform.position;
        }
        else if (isHolding == true && beamActivated == true)
        {
            itemInBeamRB.AddForce(holdLocation.transform.forward);
            isHolding = false;
            beamCooldown = 5;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Puck"))
        {
            if (beamCooldown == 0)
            {
                itemInBeam = other.gameObject;
                itemInBeamRB = other.GetComponent<Rigidbody>();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (isHolding == false)
        {
            itemInBeam = null;
            itemInBeamRB = null;
           
            
        }
    }
}
