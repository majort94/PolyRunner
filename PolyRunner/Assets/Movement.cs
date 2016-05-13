using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	GameObject[] rams;
	Vector3 beginPos;
	Vector3 EndPos;
	Vector3 currentPos;
	GameObject currentRam;
	public float speed;
	bool cycle;
	// Use this for initialization
	void Start () {
		currentRam = null;
		//cycle = false;
		rams = new GameObject[2];
		rams[0] = transform.Find("satansram").gameObject;
		rams[1] = transform.Find("satansram (1)").gameObject;
		/*rams[2] = GameObject.Find("satansram (2)");
		rams[3] = GameObject.Find("satansram (3)");*/
		//EndPos = this.transform.position;
	}

	// Update is called once per frame
	void Update () {
		if(currentRam == null)
		{
			int r = Random.Range(0,2);
			currentRam = rams[r];
			beginPos = currentRam.transform.position;
			currentPos = beginPos;
			cycle = false;
			EndPos = this.transform.position;

		}
		if(currentPos != EndPos)
		{
			currentRam.transform.position = moveToward(currentPos, EndPos);
			currentPos = currentRam.transform.position;
			if(Mathf.Abs((currentPos - EndPos).magnitude) < 10 && !cycle)
			{
				EndPos = beginPos;
				cycle = true;
			}
		}
		else
		{
			currentRam = null;
		}
	
	}

	Vector3 moveToward(Vector3 bp, Vector3 tp)
	{
		speed = 2.0f;
		Vector3 dir = tp - bp;
		dir.Normalize();
		dir = dir * speed;
		bp = bp + dir;
		return bp;

	}
}
