using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	GameObject[] rams;
	Vector3 beginPos;
	Vector3 EndPos;
	Vector3 currentPos;
	GameObject currentRam;
	bool cycle;
	// Use this for initialization
	void Start () {
		currentRam = null;
		//cycle = false;
		rams = new GameObject[4];
		rams[0] = GameObject.Find("satansram");
		rams[1] = GameObject.Find("satansram (1)");
		rams[2] = GameObject.Find("satansram (2)");
		rams[3] = GameObject.Find("satansram (3)");
		//EndPos = this.transform.position;
	}

	// Update is called once per frame
	void Update () {
		if(currentRam == null)
		{
			int r = Random.Range(0,4);
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
		int speed = 1;
		Vector3 dir = tp - bp;
		dir.Normalize();
		dir = dir * speed;
		bp = bp + dir;
		return bp;

	}
}
