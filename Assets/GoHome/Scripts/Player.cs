using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Player/PlayerMovement")]
[RequireComponent(typeof(Rigidbody))]

public class Player : MonoBehaviour {

    public float movementSpeed = 20f;
    private Rigidbody rigid;

	void Start () {
        //get reference to rigidbody
        rigid = GetComponent<Rigidbody>();
	}
	
	void Update () {

        //get input axis as float for x and y
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        //create input vector
        Vector3 input = new Vector3(inputX, 0, inputZ);

        //apply velocity
        rigid.velocity = input * movementSpeed;
	}
}
