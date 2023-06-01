using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planemovement : MonoBehaviour
{

    private Rigidbody spaceshipRB;
    float verticalMove;
    float horizontalMove;
    float mouseInputX;
    float mouseInputY;
    float tiltInput;

    //speed
    float speedMult = 1;
    float speedMultAngle = 0.5f;
    float speedtiltMultiAngle = 0.1f;

    //Thrusters amount
    public float thrust = 1000;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //keep mouse in the game
        spaceshipRB = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        verticalMove = Input.GetAxis("Vertical");
        horizontalMove = Input.GetAxis("Horizontal");
        tiltInput = Input.GetAxis("Roll");

        mouseInputX = Input.GetAxis("Mouse X");
        mouseInputY = Input.GetAxis("Mouse Y");
                
        if(Input.GetKey(KeyCode.LeftShift))
        {
            SpeedEffect.Instance.SpeedControl(true);
        }
        else
        {
            SpeedEffect.Instance.SpeedControl(false);
        }
    }
    
    void FixedUpdate()
    {
        spaceshipRB.AddForce(spaceshipRB.transform.TransformDirection(Vector3.forward) * verticalMove * speedMult, ForceMode.VelocityChange);

        spaceshipRB.AddForce(spaceshipRB.transform.TransformDirection(Vector3.right) * horizontalMove * speedMult, ForceMode.VelocityChange);

        spaceshipRB.AddTorque(spaceshipRB.transform.right * speedMultAngle * mouseInputY * -1, ForceMode.VelocityChange);
        spaceshipRB.AddTorque(spaceshipRB.transform.up * speedMultAngle * mouseInputX, ForceMode.VelocityChange);

        spaceshipRB.AddTorque(spaceshipRB.transform.forward * speedtiltMultiAngle * tiltInput, ForceMode.VelocityChange);

    }
}
