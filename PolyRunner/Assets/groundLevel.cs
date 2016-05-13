using UnityEngine;
using System.Collections;

public class groundLevel : MonoBehaviour {

    bool start = true;
    GameObject[] items;
    // Use this for initialization
    void Start () {
        items = new GameObject[transform.childCount];

        for(int i =0; i < transform.childCount; i++)
        {
            items[i] = transform.GetChild(i).gameObject;
        }

        for(int i = 0; i < items.Length; i++)
        {
            //Debug.Log("i " + items[i]);
            /*
            while((items[i].GetComponent<Collider>().bounds.center.y - items[i].GetComponent<Collider>().bounds.size.y/2) >= GameObject.Find("/hydroplane/Plane").GetComponent<Collider>().bounds.center.y)
            {
                items[i].transform.position = new Vector3(items[i].transform.position.x, items[i].transform.position.y - .05f, items[i].transform.position.z);
            }

             */

            Rigidbody rb = items[i].AddComponent<Rigidbody>();
        }
	}

    void removeRB()
    {
        for (int i = 0; i < items.Length; i++)
        {
            // Rigidbody rb = items[i].AddComponent<Rigidbody>();
           Destroy(items[i].GetComponent<Rigidbody>());
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.timeSinceLevelLoad > 10 && start)
        {
            removeRB();
            start = false;
        }
	    
	}
}
