using UnityEngine;
using System.Collections;

public class RollingRock : MonoBehaviour {

    public int speed;
    public int size;
    private bool start = false;
    //private bool start2 = false;
    
    // Use this for initialization
	void Start () {

        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        GetComponent<Rigidbody>().useGravity = false;
        //transform.GetChild(0).localScale = new Vector3(1.5f, 1.84f, 3.34f);
		//Random float for x

        /*
		float rand1 = Random.Range(1000, 2000);
		//changes between negative and positive number
		float rand2 = Random.Range(0,2);
		if(rand2 == 0) { rand1 *= -1;}
		//random float for z 
		float rand3 = Random.Range(1000, 2000);
		//changes between negative and positive number
		float rand4 = Random.Range(0,2);
		if(rand4 == 0) { rand3 *= -1;}
        //Debug.Log("X: " + rand1);
        //Debug.Log("Z: " + rand3);
        GetComponent<Rigidbody>().AddForce(new Vector3(rand1, 0.0f, rand3));
        */
    }	
    
    void Update()
    {


        if (start)
        {
            if (GetComponent<Collider>().bounds.center.z + 1 < (GameObject.Find("/hydroplane/Plane").GetComponent<Collider>().ClosestPointOnBounds(GetComponent<Collider>().bounds.center).z))
            {
                Destroy(gameObject);
            }
            if (GetComponent<Collider>().bounds.center.x + 1 < (GameObject.Find("/hydroplane/Plane").GetComponent<Collider>().ClosestPointOnBounds(GetComponent<Collider>().bounds.center).x))
            {
                Destroy(gameObject);
            }

            if (GetComponent<Collider>().bounds.center.x - 1 > (GameObject.Find("/hydroplane/Plane").GetComponent<Collider>().ClosestPointOnBounds(GetComponent<Collider>().bounds.center).x))
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if (GetComponent<Collider>().bounds.center.z < (GameObject.Find("/hydroplane/Plane").GetComponent<Collider>().ClosestPointOnBounds(GetComponent<Collider>().bounds.center + new Vector3(0f, 0f, 5f)).z ) && (GetComponent<Collider>().bounds.center.z > (GameObject.Find("/hydroplane").transform.position.z)))
            {
                start = true;
                float rand1 = Random.Range(3000, 5000);
                //changes between negative and positive number
                float rand2 = Random.Range(0, 2);
                if (rand2 == 0) { rand1 *= -1; }
                //random float for z 
                float rand3 = Random.Range(3000, 5000);
                //changes between negative and positive number
                float rand4 = Random.Range(0, 2);
                if (rand4 == 0) { rand3 *= -1; }
                //Debug.Log("X: " + rand1);
                //Debug.Log("Z: " + rand3);
                //Debug.Log("roll");
                GetComponent<Rigidbody>().AddForce(new Vector3(rand1, 0.0f, rand3));
                GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }	

}
