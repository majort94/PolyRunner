using UnityEngine;
using System.Collections;

public class MountainScript : MonoBehaviour {

	public GameObject[] fireballs;
	private Rigidbody[] rigibody;
	public int maxBalls;
	// Use this for initialization
	void Start () {
		fireballs = new GameObject[maxBalls];
		rigibody = new Rigidbody[maxBalls];
		for(int i = 0; i < maxBalls; i++)
		{
			fireballs[i] = (GameObject)Instantiate(Resources.Load("fireballPrefab"), new Vector3(1600, -20.0f, 1268 + (i + 10)), Quaternion.identity);
			fireballs[i].name = "Fireball " + i;
			rigibody[i] = fireballs[i].GetComponent<Rigidbody>();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Erupt(Vector3 eruptionLocation)
	{
		int random = Random.Range( (int)(maxBalls * .2), (int)(maxBalls * .8));
		for(int i = 0; i < random; i++)
		{
			fireballs[i].transform.position = eruptionLocation;

			rigibody[i].useGravity = true;

		}
	}
}
