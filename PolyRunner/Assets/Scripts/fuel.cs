using UnityEngine;
using System.Collections;

public class fuel : MonoBehaviour {


    private int count;
    private GameObject player;
    private bool onHit = false;
    private bool left = false;

    private int id;
    private static int idInc = 0;
	// Use this for initialization
	void Start () {

        id = idInc++;
        count = GameObject.Find("GameManager").GetComponent<stats>().count;
        player = GameObject.Find("hydroplane");

        transform.position = new Vector3(player.GetComponent<Collider>().bounds.center.x + 50f, 5f, GameObject.Find("chunk" + (count - 3).ToString()).GetComponent<Collider>().bounds.center.z);

        if(id == 1)
        {
            transform.position = new Vector3(transform.position.x - 100f, 5f, transform.position.z);
        }

        Collider[] hits = Physics.OverlapSphere(transform.position, 300f);
        //Debug.Log("hitsSize " + hits.Length);
        GameObject closestObject = null;
        GameObject obj;
        for (int i = 0; i < hits.Length; i++)
        {
            
            obj = hits[i].gameObject;
            if ((obj.layer == 8) ||(obj.layer == 12))
            {
                continue;
            }

            if (closestObject == null)
            {
                closestObject = obj;
            }
            //compares distances

            if (Vector3.Distance(transform.position, obj.transform.position) <= Vector3.Distance(transform.position, closestObject.transform.position))
            {
                closestObject = obj;
                //Debug.Log("close");
            }
        }

        Vector3 newPos = closestObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
        //Debug.Log("trasnform before " + transform.position);
        //Debug.Log("closest trans " + closestObject.transform.position);
        //Debug.Log("newPos before " + newPos);
        //Debug.Log("closest " + newPos);
        if (newPos.x < transform.position.x)
        {
            newPos.x += GetComponent<Collider>().bounds.size.x;
        }
        else
        {
            newPos.x -= GetComponent<Collider>().bounds.size.x;
        }
        //Debug.Log("trasnform before2 " + transform.position);
        transform.position = newPos;
        //Debug.Log("trasnform after " + transform.position);
        /*GameObject[] objectsWithTag = GameObject.Find("chunk" + (count - 1).ToString()).transform.gameObject.FindGameObjectsWithTag(tag);
        GameObject closestObject = null;
        for (int i = 0; i < objectsWithTag.Length; i++)
        {
            GameObject obj = objectsWithTag[i];
            if (closestObject == null)
            {
                 closestObject = obj;
              }
            //compares distances
            
            if (Vector3.Distance(transform.position, obj.transform.position) <= Vector3.Distance(transform.position, closestObject.transform.position))
            {
                closestObject = obj;
            }
        }
        */


    }
	
	// Update is called once per frame
	void Update () {
        /*
        if (!onHit)
        {
            if (player.GetComponent<Rigidbody>().velocity.x < 0f)
            {
                left = true;
                    transform.position = new Vector3(transform.position.x - 1f, 5f, transform.position.z);
            }
            else
            {
                    transform.position = new Vector3(transform.position.x + 1f, 5f, transform.position.z);
                }
        }
        */
        
    }


    public void activate()
    {
            //Debug.Log("hit2");
            GameObject.Find("hydroplane").GetComponent<fuelTimer>().start = false;
    }
    void onColliderEnter(Collision col)
    {
        /*
        if (onHit == false)
        {
            onHit = true;
            Debug.Log("hit");
            if (left)
            {
                transform.position = new Vector3(transform.position.x + 1f, 2f, transform.position.z);
            }
            else{
                transform.position = new Vector3(transform.position.x - 1f, 2f, transform.position.z);
            }
            
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<SphereCollider>().enabled = true;
        }
        else
        {
        */
        Debug.Log("hit");
        if (col.gameObject.CompareTag("player"))
            {
            Debug.Log("hit2");
            GameObject.Find("hydroplane").GetComponent<fuelTimer>().start = false;
                 Destroy(gameObject);
            }
       // }

    }
}
