using UnityEngine;
using System.Collections;

public class beam : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update() {
        //Debug.Log("dist " + Vector3.Distance(transform.parent.position, GameObject.Find("hydroplane").transform.position));
        if (Vector3.Distance(transform.parent.position, GameObject.Find("hydroplane").transform.position) <= 75f)
        {
            //Debug.Log("close");
            transform.Find("beam2").gameObject.SetActive(true);
            Vector3 targetDir = GameObject.Find("hydroplane").GetComponent<Collider>().bounds.center - transform.position;
            float step = GameObject.Find("hydroplane").GetComponent<player>().speed * Time.deltaTime;
            Vector3 newRot = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);

            //newRot.x = -90f;
            transform.rotation = Quaternion.LookRotation(newRot);

            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z - .1f);

            if(transform.position.z < GameObject.Find("hydroplane").transform.position.z)
            {
                transform.Find("beam2").gameObject.SetActive(false);
            }

        }
        else
        {
            transform.Find("beam2").gameObject.SetActive(false);
        }
      //  transform.rotation = new Quaternion()

    }
}
