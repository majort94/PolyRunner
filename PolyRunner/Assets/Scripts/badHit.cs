using UnityEngine;
using System.Collections;

public class badHit : AkTriggerBase {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void hit()
    {
        if (triggerDelegate != null)
        {
            triggerDelegate(null);
        }
    }
}
