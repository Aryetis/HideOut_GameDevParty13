using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0, 0, Input.GetAxis ("Vertical") * 2);
		transform.Translate (Input.GetAxis ("Horizontal") * 2, 0 , 0); 

	}
}
