using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDoor : MonoBehaviour {

	private Animator animBody;

	// Use this for initialization
	void Start () {
		animBody = GetComponent <Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col) {
		if (gameObject.CompareTag ("Enemy")) {

			if (col.gameObject.CompareTag ("Door")) {
				animBody.SetBool("isOpening", true);
				col.gameObject.GetComponent<DoorController>().openDoor();
				animBody.SetBool("isOpening", false);
			}
		}
	}
}
