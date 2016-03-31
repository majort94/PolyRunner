using UnityEngine;
using System.Collections;
using UnityEngine.VR;

public class rotation : MonoBehaviour {

    VRNode rift;

	// Use this for initialization
	void Start () {
        rift = VRNode.CenterEye;
        InputTracking.Recenter();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Quaternion input = InputTracking.GetLocalRotation(rift);
        transform.rotation = new Quaternion(0f, input.y, input.z, input.w);

    }
}
