using UnityEngine;
using System.Collections;
using UnityEngine.VR;

public class player : MonoBehaviour {

	// Use this for initialization
	private Transform transform;
	private float speed = 2100f;
	public Renderer rend;
	public Material mat;
	public bool forward = true;
	VRNode rift;
	void Start () {
		transform = GetComponent<Transform> ();
		//rigid = GetComponent<Rigidbody> ();
		//rigid.velocity = new Vector3 (0f, 0f, 500f);
		//cameraRigid.velocity = new Vector3 (0f, 0f, 100f);
		rift = VRNode.CenterEye;
		InputTracking.Recenter ();
		//rend = GetComponent<Renderer> ();
		//character = GetComponent<CharacterController> ();
		//Quaternion riftRotate = InputTracking.GetLocalRotation(rift);
		//character.Move (riftRotate.eulerAngles * speed);
		//Vector3 forward = transform.TransformDirection(Vector3.forward);
		//character.SimpleMove (forward * speed);

	}

	// Update is called once per frame
	void FixedUpdate () {

		transform.position = new Vector3 (transform.position.x, 5f, transform.position.z);
		if (forward) {

			Vector3 pos = Vector3.forward * speed;

			transform.Translate (pos * Time.fixedDeltaTime);
		}

	}

}
