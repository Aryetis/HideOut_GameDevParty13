using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDoor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col) {
		if (gameObject.CompareTag ("Enemy")) {

			if (col.gameObject.CompareTag ("Door")) {
				Debug.Log ("BAM LA PORTE !");
				col.gameObject.GetComponent<DoorController>().openDoor();
			}
		}
	}
}
