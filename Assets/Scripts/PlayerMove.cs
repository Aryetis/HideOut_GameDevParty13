using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float _playerSpeed;
    private float timeMove;
    private float horizontalMove;
    private float verticalMove;
    private Vector3 direction;

    // Use this for initialization
    void Start () {
        horizontalMove = 0f;
        verticalMove = 0f;
        timeMove = 0f;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        PMove();
        Debug.DrawRay(transform.position, Vector3.forward);
	}

    void PMove() {
        timeMove = Time.fixedDeltaTime;
        horizontalMove = Input.GetAxis("Horizontal") * timeMove;
        verticalMove = Input.GetAxis("Vertical") * timeMove;

//        transform.LookAt(transform.position + new Vector3(horizontalMove, 0, 0) + new Vector3(0, 0, verticalMove));

        transform.Translate(horizontalMove * _playerSpeed, 0, verticalMove * _playerSpeed);
     
    }
}
