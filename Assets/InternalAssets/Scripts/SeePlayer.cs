using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeePlayer : MonoBehaviour {

	GameObject enemy;
    public AudioClip seeEfx;
    private bool playFx = false;
    private float time;

    // Use this for initialization
    void Start () {
		enemy = GameObject.FindGameObjectWithTag ("Enemy");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider col) {
		if (gameObject.CompareTag ("Enemy")) {

			if (!col.isTrigger && col.gameObject.CompareTag ("Player")) {
				RaycastHit hit;
				if(Physics.Raycast(enemy.transform.position, (col.gameObject.transform.position - enemy.transform.position), out hit)){
					if (hit.transform == col.gameObject.transform) {
						Debug.Log ("Y A UN MEC !");
						gameObject.GetComponentInParent<MoveEnemy> ().setSeePlayer(true);      
						gameObject.GetComponentInParent<MoveEnemy> ().setGoalPosition(col.gameObject.transform.position);
					}
				}
			}
		}
	}
}
