using UnityEngine;
using System.Collections;

public class generate : MonoBehaviour {

    // Use this for initialization
    private Camera cam;
    public GameObject prevChunk;
    private GameObject nextChunk;
    private GameObject blankChunk;
    private bool begin = true;
    public GameObject cube;
    private GameObject prevObstacle = null;
    private GameObject nextObstacle = null;
    private bool end = false;
    private float spacer = 100f;
    public GameObject wave3;
    private int count = 0;


	void Start () {
        blankChunk = Instantiate(prevChunk);
        blankChunk.GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x, 0f, -10000f);
        blankChunk.tag = "blank";


    }
	
	// Update is called once per frame
	void Update () {

	}

    void generateChunk(GameObject chunk)
    {
        GameObject index = chunk.GetComponent<Transform>().Find("index").gameObject;
        while (!end)
        {
            Vector3 newPos = index.GetComponent<BoxCollider>().bounds.center;
            newPos.x += Random.Range(-1 * (spacer /2) + 10f, (spacer / 2) - 10f);
            newPos.z += Random.Range(-150f, 150f);
            nextObstacle = Instantiate(cube, newPos, Quaternion.identity) as GameObject;
            nextObstacle.GetComponent<Transform>().parent = chunk.GetComponent<Transform>();
            index.GetComponent<Transform>().position = new Vector3(index.GetComponent<Transform>().position.x + spacer, 0f, index.GetComponent<Transform>().position.z);
            if (index.GetComponent<Transform>().position.x > chunk.GetComponent<BoxCollider>().ClosestPointOnBounds(index.GetComponent<BoxCollider>().bounds.center).x)
            // if(index.GetComponent<Transform>().position.x > GetComponent<Transform>().position.x + 15500f)
            {
                end = true;
            }
        }
        

    }

    void OnTriggerEnter(Collider col)
    {
        //Debug.Log(col.gameObject.GetComponent<Transform>().name);
        if (col.gameObject.CompareTag("generator"))
        {
            count++;
            if (count > 10)
            {
                wave3.GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x + 400f, wave3.GetComponent<Transform>().position.y, col.gameObject.GetComponent<Transform>().position.z + 4000f);
                nextChunk = Instantiate(blankChunk);
                nextChunk.tag = "generator";
                nextChunk.GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x, 0f, col.gameObject.GetComponent<Transform>().position.z + 3500f);
                count = 0;
                return;
            }
                generateChunk(col.gameObject);
            end = false;

            nextChunk = Instantiate(blankChunk);
            nextChunk.tag = "generator";
            nextChunk.GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x, 0f, col.gameObject.GetComponent<Transform>().position.z + 300f);
        }
    }

    void OnTriggerExit(Collider col)
    {
        //Debug.Log("exit " + col.gameObject.GetComponent<Transform>().name);
        if (col.gameObject.CompareTag("generator") || col.gameObject.CompareTag("initial"))
        {
            Destroy(col.gameObject);
        }
    }
}
