using UnityEngine;
using System.Collections;
using UnityEngine.VR;

public class player : MonoBehaviour {

	// Use this for initialization
	private Transform transform;
	private float speed = 350f;
	public Renderer rend;
	public Material mat;
	public bool forward = true;
    public GameObject plane;
	VRNode rift;
	void Start () {
		transform = GetComponent<Transform> ();



	}

	// Update is called once per frame
	void FixedUpdate () {

		transform.position = new Vector3 (transform.position.x, 0f, transform.position.z);
		if (forward) {

            //Vector3 move = Vector3.forward * speed;
            Vector3 move = GameObject.Find("/hydroplane/body").GetComponent<Transform>().forward * speed;
            Quaternion input =  InputTracking.GetLocalRotation(rift);
			//transform.rotation = new Quaternion (0f,input.y, input.z, input.w);

			float strafe = speed * 2f;
			strafe = strafe * input.z;
            move = move + (strafe * Vector3.right);
            

			if (Input.GetKey (KeyCode.A)) {
				move = move + (Vector3.left * (speed));  
			}
			if (Input.GetKey (KeyCode.D)) {
				move = move + (Vector3.right * (speed));
			}



			transform.Translate (move * Time.fixedDeltaTime);
            GameObject plane = GameObject.Find("/hydroplane/Plane");
            plane.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(plane.GetComponent<Renderer>().material.mainTextureOffset.x - (move.x / 65f * Time.fixedDeltaTime), plane.GetComponent<Renderer>().material.mainTextureOffset.y - (move.z/ 49f * Time.fixedDeltaTime));
            //plane.GetComponent<Transform>().rotation = new Quaternion(0f, input.y, 0f, input.w);
           // plane.GetComponent<Transform>().Translate(move * Time.fixedDeltaTime);
		}

	}

}
