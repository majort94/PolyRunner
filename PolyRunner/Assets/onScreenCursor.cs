using UnityEngine;
using System.Collections;

public class onScreenCursor : MonoBehaviour {

    // Use this for initialization
    //private Transform transform;
    public GameObject cam;
	void Start () {
        //transform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = cam.GetComponent<cursor>().ray.GetPoint(100);
	
	}
}
