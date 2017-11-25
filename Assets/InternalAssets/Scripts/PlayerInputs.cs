using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour 
{
    [Range(1,4)] public int joyNumber; // use Kecode.KeyCode.Joystick[joyNumber+1]ButtonXXX for buttons , and P[joyNumber]_[Horizontal/Vertical] for axis
    public float speed;

    private float leftJoystickHorizontalInput;
    private float leftJoystickVerticalInput;
    private float rightJoystickHorizontalInput;
    private float rightJoystickVerticalInput;
    private bool buttonA;
    private bool buttonB;
    private bool buttonX;
    private bool buttonY;
    private bool lb;
    private bool rb;
    private CharacterController cc;
    private Vector3 moveVector;

	// Use this for initialization
	void Start ()
    {
        moveVector = new Vector3();
        cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        /*******************************************
         * Update inputs according to playerNumber *
         *******************************************/
        switch(joyNumber)
        {
            case 0:
            {
                leftJoystickHorizontalInput = Input.GetAxis("P1_Horizontal");
                leftJoystickVerticalInput = Input.GetAxis("P1_Vertical");
                break;
            }
            case 1:
            {
                leftJoystickHorizontalInput = Input.GetAxis("P2_Horizontal");
                leftJoystickVerticalInput = Input.GetAxis("P2_Vertical");
                break;
            }
            case 2:
            {
                leftJoystickHorizontalInput = Input.GetAxis("P3_Horizontal");
                leftJoystickVerticalInput = Input.GetAxis("P3_Vertical");
                break;
            }
            case 3:
            {
                leftJoystickHorizontalInput = Input.GetAxis("P4_Horizontal");
                leftJoystickVerticalInput = Input.GetAxis("P4_Vertical");
                break;
            }
            default: { /*Debug.LogError("playerNumber not set for a player");*/ break;}
        }

        /************************************
         *        APPLY MOVE VECTOR         *
         ************************************/
        moveVector.x = leftJoystickHorizontalInput;
        moveVector.z = leftJoystickVerticalInput;
        cc.Move(moveVector * speed * Time.deltaTime);
	}
}
