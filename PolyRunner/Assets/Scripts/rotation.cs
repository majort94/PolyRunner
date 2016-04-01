using UnityEngine;
using System.Collections;
using UnityEngine.VR;

public class rotation : MonoBehaviour {

    VRNode rift;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Quaternion input = InputTracking.GetLocalRotation(rift);
        GetComponent<Transform>().rotation = new Quaternion(0f, .8f * input.y, input.z, input.w);
    }
}
