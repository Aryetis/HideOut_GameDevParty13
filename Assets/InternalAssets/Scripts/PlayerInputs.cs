using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour 
{
    public float speed;

    private int joyNumber; // use Kecode.KeyCode.Joystick[joyNumber+1]ButtonXXX for buttons , and P[joyNumber]_[Horizontal/Vertical] for axis
    private float leftJoystickHorizontalInput;
    private float leftJoystickVerticalInput;
    private bool buttonA;
    private bool buttonB;
    private bool buttonX;
    private bool buttonADown;
    private bool buttonBDown;
    private bool buttonXDown;
    private CharacterController cc;
    private Vector3 moveVector;
    private bool allowMovement;

	// Use this for initialization
	void Start ()
    {
        allowMovement = false;
        moveVector = new Vector3();
        cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        /*******************************************
         * Update inputs according to playerNumber *
         *******************************************/
        leftJoystickHorizontalInput = Input.GetAxis("J" + joyNumber + "_Horizontal");
        leftJoystickVerticalInput = Input.GetAxis("J" + joyNumber + "_Vertical");
        buttonA = Input.GetButton("J" + joyNumber + "_A");
        buttonADown = Input.GetButtonDown("J" + joyNumber + "_A");
        buttonB = Input.GetButton("J" + joyNumber + "_B");
        buttonBDown = Input.GetButtonDown("J" + joyNumber + "_B");
        buttonX = Input.GetButton("J" + joyNumber + "_X");
        buttonXDown = Input.GetButtonDown("J" + joyNumber + "_X");

        /************************************
         *        APPLY MOVE VECTOR         *
         ************************************/
        if(allowMovement)
        {
            moveVector.x = leftJoystickHorizontalInput;
            moveVector.y = 0;
            moveVector.z = leftJoystickVerticalInput;
            cc.Move(moveVector * speed * Time.deltaTime);
        }
	}

    public void SetJoyNumber(int joyNumber_)
    {
        joyNumber = joyNumber_;
    }

    public void SetAllowMovement(bool allowMovement_)
    {
        allowMovement = allowMovement_;
    }
}
