using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour {

	private Animator animBody;

	// Use this for initialization
	void Start () {
		animBody = GetComponent <Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnControllerColliderHit(ControllerColliderHit hit){
		if (gameObject.CompareTag ("Player")) {
			
			if (hit.collider.gameObject.CompareTag ("Enemy")) {
				hit.collider.gameObject.GetComponent<Animator>().SetBool("isPunching", true);
				animBody.SetBool("isDead", true);
				GetComponent<PlayerInputs>().SetAllowMovement(false);
				Invoke ("Disappear", 5);
				hit.collider.gameObject.GetComponent<Animator>().SetBool("isPunching", false);
			}
		}
	}

	void Disappear(){
		gameObject.active = false;
		animBody.SetBool("isDead", false);
	}
}
