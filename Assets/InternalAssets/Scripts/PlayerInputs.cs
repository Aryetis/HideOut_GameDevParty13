using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour 
{
    public float speed;
    public AudioClip runEfx;

    private int joyNumber; // use Kecode.KeyCode.Joystick[joyNumber+1]ButtonXXX for buttons , and P[joyNumber]_[Horizontal/Vertical] for axis
    private float leftJoystickHorizontalInput;
    private float leftJoystickVerticalInput;
    public bool buttonA { get; private set; }
	public bool buttonB { get; private set; }
	public bool buttonX { get; private set; }
	public bool buttonADown { get; private set; }
	public bool buttonBDown { get; private set; }
	public bool buttonXDown { get; private set; }
	public bool buttonAUp { get; private set; }
	public bool buttonBUp { get; private set; }
	public bool buttonXUp { get; private set; }
	private CharacterController cc;
	[SerializeField]
    public Vector3 moveVector;
    private bool allowMovement;
	private Animator animBody;

	// Use this for initialization
	void Start ()
    {
        allowMovement = false;
        moveVector = new Vector3();
        cc = GetComponent<CharacterController>();
		animBody = GetComponent <Animator> ();
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
		buttonAUp = Input.GetButtonUp("J" + joyNumber + "_A");
		buttonB = Input.GetButton("J" + joyNumber + "_B");
        buttonBDown = Input.GetButtonDown("J" + joyNumber + "_B");
        buttonBUp = Input.GetButtonUp("J" + joyNumber + "_B");
        buttonX = Input.GetButton("J" + joyNumber + "_X");
        buttonXDown = Input.GetButtonDown("J" + joyNumber + "_X");
		buttonXUp = Input.GetButtonUp("J" + joyNumber + "_X");

		/************************************
         *        APPLY MOVE VECTOR         *
         ************************************/
		if (allowMovement)
        {
            moveVector.x = leftJoystickHorizontalInput;
            moveVector.y = 0;
            moveVector.z = leftJoystickVerticalInput;
            cc.Move(moveVector * speed * Time.deltaTime);
			transform.LookAt(transform.position + moveVector);
			animBody.SetFloat("runSpeed", Mathf.Abs(moveVector.x)+Mathf.Abs(moveVector.z));
        }
	}

	public void FixedUpdate() {
		transform.position = new Vector3(transform.position.x, -1.5f, transform.position.z);
	}

	public void SetJoyNumber(int joyNumber_)
    {
        joyNumber = joyNumber_;
    }

    public void SetAllowMovement(bool allowMovement_)
    {
        allowMovement = allowMovement_;
    }

	public bool GetAllowMovement() {
		return allowMovement;
	}
}
