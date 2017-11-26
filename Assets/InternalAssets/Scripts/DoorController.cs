using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

	public float cooldownCloseDoor = 5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void openDoor(){
		gameObject.transform.Translate (0,-20,0);
		gameObject.GetComponent<BoxCollider> ().enabled = false;
		//Invoke("closeDoor", cooldownCloseDoor);
	}

	public void closeDoor(){
		GetComponent<BoxCollider> ().enabled = true;
		gameObject.transform.Translate (0,20,0);
	}
}
