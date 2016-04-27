using UnityEngine;
using System.Collections;

public class sidesMoveBasic : MonoBehaviour {

    // Use this for initialization
    public GameObject player;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z + 5119f);
	}
}
