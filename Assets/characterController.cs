using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour {

    public float speed = 5.0f;

    // Use this for initialization
    void Start () {
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {

        // CN 11/05/18: WASD movement
        float forwardOrBack = Input.GetAxis("Vertical") * speed;
        float leftOrRight = Input.GetAxis("Horizontal") * speed;
        forwardOrBack = forwardOrBack * Time.deltaTime;
        leftOrRight = leftOrRight * Time.deltaTime;
        transform.Translate(leftOrRight, 0, forwardOrBack);
		
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Cursor.lockState = CursorLockMode.None;
        }
	}
}
