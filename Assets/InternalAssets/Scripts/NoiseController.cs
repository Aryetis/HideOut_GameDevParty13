using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("DestroyCollidNoise", 2);
		Invoke ("DestroyNoise", 10);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void DestroyCollidNoise(){
		gameObject.GetComponent<SphereCollider>().enabled = false;
	}

	void DestroyNoise(){
		Destroy(gameObject);
	}
}
