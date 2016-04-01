using UnityEngine;
using System.Collections;

public class cube : MonoBehaviour {

	public Material mat;
	public GameObject mesh01;
	bool hit = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter(Collider col){
        if (col.gameObject == GameObject.Find("hydroplane"))
        {
            if (!hit)
            {
                GameObject.Find("/hydroplane/body").GetComponent<MeshRenderer>().material = mat;
                GameObject.Find("hydroplane").GetComponent<player>().forward = false;
                GameObject.Find("/hydroplane/body").transform.parent = null;
                hit = true;
            }
        }
	}

}
