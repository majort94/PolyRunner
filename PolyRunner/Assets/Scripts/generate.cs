using UnityEngine;
using System.Collections;
using System;


public class generate : MonoBehaviour {

    // Use this for initialization
    private Camera cam;
    public GameObject prevChunk;
    private GameObject nextChunk;
    private GameObject blankChunk;
    private bool begin = true;
    public GameObject cube;
    private GameObject prevObstacle;
    private GameObject nextObstacle = null;
    private bool end = false;
    private float spacer = 100f;
    public GameObject wave3;
    private int count = 0;


    //generation stuff
    Boolean prog1 = false;
    Boolean prog2 = false;
    Boolean prog3 = false;
    Boolean prog4 = false;
    Boolean prog5 = false;
    Boolean prog6 = false;
    public GameObject[] obstacles;

	void Start () {
        blankChunk = Instantiate(prevChunk);
        blankChunk.GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x, 0f, -10000f);
        blankChunk.tag = "blank";
        prevObstacle = cube;


    }
	
	// Update is called once per frame
	void Update () {

	}

    void generateChunk(GameObject chunk)
    {
        GameObject index = chunk.GetComponent<Transform>().Find("index").gameObject;
        while (!end)
        {
            spacer = 100f;
            Vector3 newPos = index.GetComponent<BoxCollider>().bounds.center;

            //newPos.x += UnityEngine.Random.Range(-1 * (spacer /2) + 10f, (spacer / 2) - 10f);
            //newPos.x += UnityEngine.Random.Range(-1 * (prevObstacle.GetComponent<Collider>().bounds.size.x), (prevObstacle.GetComponent<Collider>().bounds.size.x));
            //newPos.x += (prevObstacle.GetComponent<Collider>().bounds.size.x);
            newPos.z += UnityEngine.Random.Range(-150f, 150f);
            GameObject temp = pickObstacle(count);
            index.GetComponent<Transform>().position = new Vector3(index.GetComponent<Transform>().position.x + prevObstacle.GetComponent<Collider>().bounds.size.x + spacer, 0f, index.GetComponent<Transform>().position.z);
            newPos.x += UnityEngine.Random.Range(0f, temp.GetComponent<Collider>().bounds.size.x * 2);
            prevObstacle = temp;
            nextObstacle = Instantiate(temp, newPos, Quaternion.identity) as GameObject;
            nextObstacle.GetComponent<Transform>().parent = chunk.GetComponent<Transform>(); 
            //index.GetComponent<Transform>().position = new Vector3(index.GetComponent<Transform>().position.x + spacer, 0f, index.GetComponent<Transform>().position.z);
            if (index.GetComponent<Transform>().position.x > chunk.GetComponent<BoxCollider>().ClosestPointOnBounds(index.GetComponent<BoxCollider>().bounds.center).x)
            // if(index.GetComponent<Transform>().position.x > GetComponent<Transform>().position.x + 15500f)
            {
                end = true;
            }
        }
        

    }

    private GameObject pickObstacle(int count)
    {
        int rand = 0;
        rand = (int)UnityEngine.Random.Range(0f, 100f);



        // use # of chunk generations to introduce new progressions to chunk generation; new obstacles
        switch (count)
        {
            case 5:
                prog1 = true;
                break;
            case 10:
                prog1 = false;
                prog2 = true;
                break;
            case 25:
                //prog2 = false;
                //prog3 = true;
                break;
            default:
                break;
        }
        if (prog1)
        {
            if(rand < 10)
            {
                return obstacles[1];
            }
        }
        if (prog2)
        {
            if (rand < 10)
            {
                return obstacles[1];
            }
            else
            {
                if(rand <20)
                {
                    return obstacles[2];
                }
            }
        }


                return obstacles[0];
    }

    void OnTriggerEnter(Collider col)
    {
        //Debug.Log(col.gameObject.GetComponent<Transform>().name);
        if (col.gameObject.CompareTag("generator"))
        {
            count++;
            if (count % 20 == 0)
            {
                wave3.GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x + 400f, wave3.GetComponent<Transform>().position.y, col.gameObject.GetComponent<Transform>().position.z + 4000f);
                nextChunk = Instantiate(blankChunk);
                nextChunk.tag = "generator";
                nextChunk.GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x, 0f, col.gameObject.GetComponent<Transform>().position.z + 3500f);
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
