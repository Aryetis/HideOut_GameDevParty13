using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearNoise : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter(Collider col) {
		if (gameObject.CompareTag ("Enemy")) {

			if (!col.isTrigger && col.gameObject.CompareTag ("Sound")) {
				Debug.Log ("Y A DU BRUIT !");
				gameObject.GetComponentInParent<MoveEnemy> ().setHearNoise(true);
				gameObject.GetComponentInParent<MoveEnemy> ().setSoundTarget(col.gameObject);
			}
		}
	}

}
