using UnityEngine;
using System.Collections;

public class fuelPickup : MonoBehaviour {

    GameObject playerRef;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void onTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            playerRef.GetComponent<fuelTimer>().fuelBarScale += 0.005f;
        }
        Destroy(this.gameObject);
    }
}
