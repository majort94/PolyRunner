using UnityEngine;
using System.Collections;

public class RollingRock : MonoBehaviour {

    public int speed;
    public int size;
    
    // Use this for initialization
	void Start () {
		//Random float for x
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
		this.GetComponent<Rigidbody>().AddForce( new Vector3(rand1, 0.0f, rand3));
	
	}	
    
    void Update()
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
}
