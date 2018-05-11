using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMouseLook : MonoBehaviour {

    Vector2 mouseLook;
    Vector2 smoothVector;
    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;
    GameObject character;

	void Start () {
        character = transform.parent.gameObject;
	}
	
	void Update () {
        // CN 11/05/18 Get mouse look and adjust for smoothing and sensitivity
        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothVector.x = Mathf.Lerp(smoothVector.x, mouseDelta.x, 1f / smoothing);
        smoothVector.y = Mathf.Lerp(smoothVector.y, mouseDelta.y, 1f / smoothing);
        mouseLook += smoothVector;
        // CN 11/05/18 Limits Y axis rotation (i.e. straight up to straight down)
        mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);

        // CN 11/05/18 Apply up/down rotation to camera, left/right to character
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);

    }
}
