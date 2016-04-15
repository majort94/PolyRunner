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

    private int count = 0;


    //generation stuff
    public GameObject wave3;
    public GameObject wave4;

    Boolean prog1 = false;
    Boolean prog2 = false;
    Boolean prog3 = false;
    Boolean prog4 = false;
    Boolean prog5 = false;
    Boolean prog6 = false;

    public Material[] mats;

    private Boolean forwardSlash = false;
    private Boolean backSlash = false;
    private Boolean nonSlash = true;
    private float prevZ;
    private int slashIterator = 0;

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
            int rand = 0;
            rand = (int)UnityEngine.Random.Range(0f, 100f);

            

            //newPos.x += UnityEngine.Random.Range(-1 * (spacer /2) + 10f, (spacer / 2) - 10f);
            //newPos.x += UnityEngine.Random.Range(-1 * (prevObstacle.GetComponent<Collider>().bounds.size.x), (prevObstacle.GetComponent<Collider>().bounds.size.x));
            //newPos.x += (prevObstacle.GetComponent<Collider>().bounds.size.x);
            
            GameObject temp = pickObstacle(count);
            if((forwardSlash || backSlash ) && slashIterator < 4){
                temp = prevObstacle;
            }
            index.GetComponent<Transform>().position = new Vector3(index.GetComponent<Transform>().position.x + (prevObstacle.GetComponent<Collider>().bounds.size.x/2 + spacer), 0f, index.GetComponent<Transform>().position.z);

            if (forwardSlash || backSlash)
            {
                index.GetComponent<Transform>().position = new Vector3(index.GetComponent<Transform>().position.x - (spacer/2) + (temp.GetComponent<Collider>().bounds.size.x / 2), 0f, index.GetComponent<Transform>().position.z);
            }
            Vector3 newPos = index.GetComponent<BoxCollider>().bounds.center;

            //GameObject temp2 = Instantiate(temp, index.GetComponent<Transform>().position, Quaternion.identity) as GameObject;
            //temp2.GetComponent<Transform>().Find("polySurface1").GetComponent<MeshRenderer>().material = mats[4];

            if (!backSlash && !forwardSlash && (rand < 10))
            {
                forwardSlash = true;
            }
            if (!forwardSlash && !backSlash && (rand > 10) && (rand < 20))
            {
                backSlash = true;
            }

            if (!nonSlash)
            {
                nonSlash = true;
            }
            // if making a slash pattern, else normal random range 
            if (forwardSlash && slashIterator < 4)
            {
                //newPos.x += UnityEngine.Random.Range(0f, temp.GetComponent<Collider>().bounds.size.x*10f);
               // newPos.x -= spacer;
                //Debug.Log("forwardSlash");
                switch (slashIterator)
                {
                    case 0:
                        prevZ = UnityEngine.Random.Range(-150f, 150f);
                        newPos.z += prevZ;
                        //temp.GetComponent<Transform>().Find("polySurface1").GetComponent<MeshRenderer>().material = mats[0];
                        slashIterator++;
                        break;
                    case 1:
                        newPos.z += UnityEngine.Random.Range(prevZ - 50f, prevZ - 100f);
                        // temp.GetComponent<Transform>().Find("polySurface1").GetComponent<MeshRenderer>().material = mats[1];
                        slashIterator++;
                        break;
                    case 2:
                        newPos.z += UnityEngine.Random.Range(prevZ - 100f, prevZ - 150f);
                        slashIterator++;
                        //temp.GetComponent<Transform>().Find("polySurface1").GetComponent<MeshRenderer>().material = mats[2];
                        break;
                    case 3:
                        newPos.z += UnityEngine.Random.Range(prevZ - 150f, prevZ - 200f);
                      //  slashIterator++;
                        //temp.GetComponent<Transform>().Find("polySurface1").GetComponent<MeshRenderer>().material = mats[2];
                       // break;
                   // case 4:
                       // newPos.z += UnityEngine.Random.Range(prevZ - 200f, prevZ - 250f);
                        //temp.GetComponent<Transform>().Find("polySurface1").GetComponent<MeshRenderer>().material = mats[2];
                        slashIterator = 0;
                        forwardSlash = false;
                        backSlash = false;
                        nonSlash = false;
                        break;
                    default:
                        break;
                }
                
            }
 
                if (backSlash && slashIterator < 5)
                {
                   // newPos.x += UnityEngine.Random.Range(0f, temp.GetComponent<Collider>().bounds.size.x * 10f);
                    //newPos.x -= spacer;
                    //Debug.Log("backSlash");
                    switch (slashIterator)
                    {
                        case 0:
                        prevZ = UnityEngine.Random.Range(-150f, 150f);
                        newPos.z += prevZ;
                        //temp.GetComponent<Transform>().Find("polySurface1").GetComponent<MeshRenderer>().material = mats[0];
                        slashIterator++;
                            break;
                        case 1:
                            newPos.z += UnityEngine.Random.Range(prevZ + 50f, prevZ + 100f);
                            //temp.GetComponent<Transform>().Find("polySurface1").GetComponent<MeshRenderer>().material = mats[1];
                            slashIterator++;
                            break;
                    case 2:
                        newPos.z += UnityEngine.Random.Range(prevZ + 100f, prevZ + 150f);
                        slashIterator++;
                        // temp.GetComponent<Transform>().Find("polySurface1").GetComponent<MeshRenderer>().material = mats[2];
                        break;
                    case 3:
                        newPos.z += UnityEngine.Random.Range(prevZ + 150f, prevZ + 200f);
                        slashIterator++;
                        // temp.GetComponent<Transform>().Find("polySurface1").GetComponent<MeshRenderer>().material = mats[2];
                        break;
                    case 4:
                        newPos.z += UnityEngine.Random.Range(prevZ + 200f, prevZ + 250f);
                        // temp.GetComponent<Transform>().Find("polySurface1").GetComponent<MeshRenderer>().material = mats[2];
                        slashIterator = 0;
                        forwardSlash = false;
                        backSlash = false;
                        nonSlash = false;
                        break;
                    default:
                            break;
                    }
                }

                /*else
                {

                    //temp.GetComponent<Transform>().Find("polySurface1").GetComponent<MeshRenderer>().material = mats[3];
                    //temp2.GetComponent<Transform>().Find("polySurface1").GetComponent<MeshRenderer>().material = mats[3];
                    slashIterator = 0;
                    forwardSlash = false;
                    backSlash = false;
                    //Debug.Log("here");
                }
                */
    
            if (!forwardSlash && !backSlash && nonSlash)
            {
                newPos.z += UnityEngine.Random.Range(-150f, 150f);
                newPos.x += UnityEngine.Random.Range(-.9f * spacer, spacer);
                //temp.GetComponent<Transform>().Find("polySurface1").GetComponent<MeshRenderer>().material = mats[4];
            }
            //newPos.z += UnityEngine.Random.Range(-150f, 150f);
            //newPos.x += UnityEngine.Random.Range(0f, temp.GetComponent<Collider>().bounds.size.x * 2);
            //index.GetComponent<Transform>().position = new Vector3(newPos.x, 0f, index.GetComponent<Transform>().position.z);
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
                spacer = 70f;
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
                else
                {
                    if (rand < 25)
                    {
                        return obstacles[3];
                    }
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
            GameObject temp;
           /* if (count % 9999 == 0)
            {
                //wave4.GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x + 400f, wave4.GetComponent<Transform>().position.y, 0f);
                wave4.GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x + 400f, wave4.GetComponent<Transform>().position.y, col.gameObject.GetComponent<Transform>().position.z +  15300f);
                
                for (int i = 0; i < 2; i++)
                {
                    //Vector3 pos1 = new Vector3((GetComponent<Transform>().position.x + 400f) - ((i + 1) * wave4.GetComponent<BoxCollider>().bounds.size.x), wave4.GetComponent<Transform>().position.y, col.gameObject.GetComponent<Transform>().position.z + 4000f);
                    Vector3 pos1 = new Vector3((GetComponent<Transform>().position.x + 400f) - ((i + 1) * wave4.GetComponent<BoxCollider>().bounds.size.x), wave4.GetComponent<Transform>().position.y, col.gameObject.GetComponent<Transform>().position.z + 15300f);
                    temp = Instantiate(wave4, pos1, Quaternion.identity) as GameObject;
                }
                for (int i = 0; i < 2; i++)
                {
                    Vector3 pos1 = new Vector3((GetComponent<Transform>().position.x + 400f) + ((i + 1) * wave4.GetComponent<BoxCollider>().bounds.size.x), wave4.GetComponent<Transform>().position.y, col.gameObject.GetComponent<Transform>().position.z + 15300f);
                    temp = Instantiate(wave4, pos1, Quaternion.identity) as GameObject;
                }

                nextChunk = Instantiate(blankChunk);
                nextChunk.tag = "generator";
                nextChunk.GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x, 0f, col.gameObject.GetComponent<Transform>().position.z +  wave4.GetComponent<BoxCollider>().bounds.size.z/2);
                return;
            }
            else {
                */
                if (count % 20 == 0)
                {
                    wave3.GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x + 400f, wave3.GetComponent<Transform>().position.y, col.gameObject.GetComponent<Transform>().position.z + 4000f);
                    for (int i = 0; i < 2; i++)
                    {
                        Vector3 pos1 = new Vector3((GetComponent<Transform>().position.x + 400f) - ((i + 1) * wave3.GetComponent<BoxCollider>().bounds.size.x), wave3.GetComponent<Transform>().position.y, col.gameObject.GetComponent<Transform>().position.z + 4000f);
                        temp = Instantiate(wave3, pos1, Quaternion.identity) as GameObject;
                    }
                    for (int i = 0; i < 2; i++)
                    {
                        Vector3 pos1 = new Vector3((GetComponent<Transform>().position.x + 400f) + ((i + 1) * wave3.GetComponent<BoxCollider>().bounds.size.x), wave3.GetComponent<Transform>().position.y, col.gameObject.GetComponent<Transform>().position.z + 4000f);
                        temp = Instantiate(wave3, pos1, Quaternion.identity) as GameObject;
                    }

                    nextChunk = Instantiate(blankChunk);
                    nextChunk.tag = "generator";
                    //nextChunk.GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x, 0f, col.gameObject.GetComponent<Transform>().position.z - 4000f + wave3.GetComponent<BoxCollider>().bounds.size.z/2);
                    nextChunk.GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x, 0f, col.gameObject.GetComponent<Transform>().position.z + 3500f);
                    return;
                }
                
           // }
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
