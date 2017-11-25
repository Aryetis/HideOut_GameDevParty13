﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
    private Collider boxCollider;
    private Collider colliderAttack;
    [SerializeField]
    private float blurCoeff;

	// Use this for initialization
	void Start () {
        boxCollider = GetComponent<BoxCollider>();
        colliderAttack = boxCollider.GetComponent<Collider>();
        colliderAttack.enabled = false;

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E)) {
            colliderAttack.enabled = true;
            PunchAttack();
        }
        if (Input.GetKeyUp(KeyCode.E)) {
            colliderAttack.enabled = false;
        }
	}

    void OnTriggerEnter(Collider collider) {
        if (collider.CompareTag("Player")) {
            PlayerController punch = collider.GetComponent<PlayerController>();
            punch.addPunchReceived();
            if(punch.getPunchReceived() == 1) {
                ReduceFov(blurCoeff);
            }
            if(punch.getPunchReceived() == 2) {
                ReduceFov(blurCoeff*2);
            }
            if(punch.getPunchReceived() == 3) {
                Debug.Log(punch.getPunchReceived());
                StuntEffect();
                ReduceFov(blurCoeff*3);
                punch.initPunch();

            }
            Debug.Log(collider.GetComponent<PlayerController>().getPunchReceived());
        }
    }

    //TODO: set punch animation
    void PunchAttack() {
        Debug.Log("PUCNH !!  ");
    }

    //TODO: stunt
    void StuntEffect() {
        Debug.Log(" = STUNT");
    }

    //TODO: Reducingfov with blur
    void ReduceFov(float blurCoeff) {
        Debug.Log("blur : " + blurCoeff);
    }
}
