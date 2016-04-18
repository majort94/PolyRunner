using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	GameObject[] rams;
	// Use this for initialization
	void Start () {
		rams = new GameObject[4];
		rams[0] = GameObject.Find("satansram");
		rams[1] = GameObject.Find("satansram (1)");
		rams[2] = GameObject.Find("satansram (2)");
		rams[3] = GameObject.Find("satansram (3)");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
