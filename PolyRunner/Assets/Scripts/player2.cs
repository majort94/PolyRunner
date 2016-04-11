using UnityEngine;
using System.Collections;
using UnityEngine.VR;

public class player2 : MonoBehaviour {

	// Use this for initialization
	private Transform transform;
	private float speed = 200f;
	public Renderer rend;
	public Material mat;
	public bool forward = true;
	VRNode rift;
	void Start () {
		transform = GetComponent<Transform> ();



	}

	// Update is called once per frame
	void FixedUpdate () {

		transform.position = new Vector3 (transform.position.x, 0f, transform.position.z);
		if (forward) {

			Vector3 move = Vector3.forward * speed;
			Quaternion input =  InputTracking.GetLocalRotation(rift);
			//transform.rotation = new Quaternion (0f,input.y, input.z, input.w);

			float strafe = speed * 1.25f;
			strafe = strafe * input.z;
			move = move + (strafe * Vector3.right);

			if (Input.GetKey (KeyCode.A)) {
				move = move + (Vector3.left * (speed));  
			}
			if (Input.GetKey (KeyCode.D)) {
				move = move + (Vector3.right * (speed));
			}



			transform.Translate (move * Time.fixedDeltaTime);
		}

	}

}
