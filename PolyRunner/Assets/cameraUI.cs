using UnityEngine;
using System.Collections;
using UnityEngine.VR;

public class cameraUI : MonoBehaviour {

	private Transform transform;
	// Use this for initialization
	void Start () {
		transform = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = new Quaternion (0f, 0f, 0f, 0f);
	}

}
