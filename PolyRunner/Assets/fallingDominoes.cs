using UnityEngine;
using System.Collections;

public class fallingDominoes : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider col)
    {

        //if (col.gameObject.CompareTag("Player"))
        if (col.gameObject == GameObject.Find("hydroplane"))
        {
           
            int size = GetComponent<Transform>().childCount;
            for(int i = 0; i < size; i++)
            {
                //Debug.Log("yesss " + transform.GetChild(i).gameObject);
                transform.GetChild(i).gameObject.GetComponent<Rigidbody>().useGravity = true;
                //transform.GetChild(i).gameObject.GetComponent<Rigidbody>().gravityScale = 5f;
            }
        }

        }
    }
