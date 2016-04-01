using UnityEngine;
using System.Collections;
using UnityEngine.VR;

public class rotate : MonoBehaviour {

	private Transform transform;
	public VRNode center;
	// Use this for initialization
	void Start () {
		transform = GetComponent<Transform> ();
		center = VRNode.CenterEye;
	}
	
	// Update is called once per frame
	void Update () {

		//Debug.Log (center.GetComponent<Transform> ().rotation.z);

		//Quaternion rotation = new Quaternion (0f, 0f, InputTracking.GetLocalRotation(center).z, 0f);   
		Quaternion input =  InputTracking.GetLocalRotation(center);
		transform.rotation = new Quaternion (0f, 2 * input.y, input.z, input.w);
		//transform.position = new Vector3 (transform.position.x, 50f, transform.position.z);
	}
}
