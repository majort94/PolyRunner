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


	void Start () {
        blankChunk = Instantiate(prevChunk);
        blankChunk.GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x, 0f, -10000f);


    }
	
	// Update is called once per frame
	void Update () {

	}

    void generateChunk(GameObject chunk)
    {
        while (!end)
        {
            GameObject index = chunk.GetComponent<Transform>().GetChild(0).gameObject;
            index.GetComponent<Transform>().position = new Vector3(index.GetComponent<Transform>().position.x + spacer, 0f, index.GetComponent<Transform>().position.z);
            Vector3 newPos = index.GetComponent<BoxCollider>().bounds.center;
            nextObstacle = Instantiate(cube, newPos, Quaternion.identity) as GameObject;
            nextObstacle.GetComponent<Transform>().parent = chunk.GetComponent<Transform>();
            if(index.GetComponent<Transform>().position.x > chunk.GetComponent<BoxCollider>().ClosestPointOnBounds(index.GetComponent<BoxCollider>().bounds.center).x)
            {
                end = true;
            }
        }

    }

    void OnTriggerEnter(Collider col)
    {
        generateChunk(col.gameObject);
        end = false;
        nextChunk = Instantiate(blankChunk);
        nextChunk.GetComponent<Transform>().position = new Vector3(col.gameObject.GetComponent<Transform>().position.x, 0f, col.gameObject.GetComponent<Transform>().position.z + 300f);
    }
}
