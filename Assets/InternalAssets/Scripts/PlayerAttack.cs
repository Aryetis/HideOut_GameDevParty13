using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
    private Collider boxCollider;
    private Collider colliderAttack;

	private PlayerInputs inputs;
	public PlayerCamera pcam;
	private PlayerFOV playerfov;

	private int punchReceived;

	public float stunDuration;
	private float stunTime;
	private bool isStunned;
	private Animator animBody;
	private PlayerAttack plaAttack;
    public AudioClip punchEfx;

	// Use this for initialization
	void Start () {
        boxCollider = GetComponent<BoxCollider>();
		colliderAttack = boxCollider as Collider;
        colliderAttack.enabled = false;
		inputs = GetComponent<PlayerInputs>();
		playerfov = GetComponent<PlayerFOV>();
		animBody = GetComponent <Animator> ();
    }
	
	// Update is called once per frame
	void Update () {
		if (isStunned && stunTime + stunDuration <= Time.time) {
			isStunned = false;
			inputs.SetAllowMovement(true);
			punchReceived = 0;
			SetVisibility(0);
		}
        if (inputs.buttonXDown) {
			animBody.SetBool("isPunching", true);
            colliderAttack.enabled = true;
            SoundManager.instance.PlaySingle(punchEfx);
            PunchAttack();

        }
        if (inputs.buttonXUp) {
            colliderAttack.enabled = false;
			animBody.SetBool("isPunching", false);
        }
	}

    void OnTriggerEnter(Collider collider) {
        if (collider.CompareTag("Player") && !collider.isTrigger && inputs.GetAllowMovement()) {
			plaAttack = collider.GetComponent<PlayerAttack>();
			Debug.Log("coll" + collider);
			Debug.Log("down: " + inputs.buttonXDown, gameObject);
			Debug.Log("up: " + inputs.buttonXUp, gameObject);
			plaAttack.punchReceived++;
            if(plaAttack.punchReceived == 1) {
				plaAttack.SetVisibility(1);
				plaAttack.Stun(false);
			}
            else if(plaAttack.punchReceived == 2) {
				plaAttack.SetVisibility(2);
				plaAttack.Stun(false);
			}
            else if(plaAttack.punchReceived == 3) {
				Debug.Log ("T'ES MORT !");
				plaAttack.animBody.SetBool("isKnocked", true);
                Debug.Log(plaAttack.punchReceived);
				plaAttack.SetVisibility(3);
				plaAttack.Stun(true);

            }
            Invoke("Stun", 1);
        }
    }

    //TODO: set punch animation
    void PunchAttack() {
        Debug.Log("PUCNH !!");
    }

	void Stun(){
		plaAttack.animBody.SetBool("isKnocked", false);
	}
	
	//TODO: stun anim
    void Stun(bool freezeMovement) {
		stunTime = Time.time;
		isStunned = true;
		inputs.SetAllowMovement(!freezeMovement);
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
