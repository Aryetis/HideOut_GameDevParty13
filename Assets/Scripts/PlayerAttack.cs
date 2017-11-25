using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
    private Collider boxCollider;
    private Collider colliderAttack;

	private PlayerInputs inputs;
	public PlayerCamera pcam;
	private PlayerFOV playerfov;

	public float stunDuration;
	private float stunTime;
	private bool isStunned;

	// Use this for initialization
	void Start () {
        boxCollider = GetComponent<BoxCollider>();
		colliderAttack = boxCollider as Collider;
        colliderAttack.enabled = false;
		inputs = GetComponent<PlayerInputs>();
		playerfov = GetComponent<PlayerFOV>();
    }
	
	// Update is called once per frame
	void Update () {
		if (isStunned && stunTime + stunDuration <= Time.time) {
			isStunned = false;
			inputs.SetAllowMovement(true);
			SetVisibility(0);
		}
        if (inputs.buttonADown) {
            colliderAttack.enabled = true;
            PunchAttack();
        }
        if (inputs.buttonAUp) {
            colliderAttack.enabled = false;
        }
	}

    void OnTriggerEnter(Collider collider) {
        if (collider.CompareTag("Player") && !collider.isTrigger) {
            PlayerController plaController = collider.GetComponent<PlayerController>();
			PlayerAttack plaAttack = collider.GetComponent<PlayerAttack>();
			Debug.Log("coll" + collider);
			Debug.Log("down: " + inputs.buttonADown, gameObject);
			Debug.Log("up: " + inputs.buttonAUp, gameObject);
			plaController.AddPunchReceived();
            if(plaController.GetPunchReceived() == 1) {
				plaAttack.SetVisibility(1);
            }
            else if(plaController.GetPunchReceived() == 2) {
				plaAttack.SetVisibility(2);
            }
            else if(plaController.GetPunchReceived() == 3) {
                Debug.Log(plaController.GetPunchReceived());
				plaAttack.Stun();
				plaAttack.SetVisibility(3);
                plaController.InitPunch();

            }
            Debug.Log(collider.GetComponent<PlayerController>().GetPunchReceived());
        }
    }

    //TODO: set punch animation
    void PunchAttack() {
        Debug.Log("PUCNH !!");
    }
	
	//TODO: stun anim
    void Stun() {
		stunTime = Time.time;
		isStunned = true;
		inputs.SetAllowMovement(false);
    }
	
	void SetVisibility(int visibilityCoeff) {
		Debug.Log("blur : " + visibilityCoeff);
		if (visibilityCoeff != 0) {
			pcam.isBlurActive = true;
			pcam.downRes = visibilityCoeff;
			playerfov.Intensity = 1f / visibilityCoeff;
		} else {
			pcam.isBlurActive = false;
			playerfov.Intensity = 1f;
		}
	}

}
