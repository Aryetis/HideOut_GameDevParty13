using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeANoise : MonoBehaviour {

	public GameObject noisePrefab;
	public GameObject noise;
	public GameObject enemy;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("g")) {
			noise = Instantiate (noisePrefab, noisePrefab.transform.position, Quaternion.identity);
		}
	}
}
