using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class fuelTimer : MonoBehaviour {

    public GameObject playerRef;
    public GameObject fuelBar;
    public Text fuelText;
    bool goingDown = true;
    public float fuelBarScale = 1;
    float lastTime;
    public Material gameOverMat;
    public bool start = false;
    private bool norm = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame

    public void onHit()
    {
        fuelBarScale = fuelBarScale - 0.20f;
    }

    public void pickup()
    {
        //Debug.Log("scaling");
        //fuelBarScale = fuelBarScale + 0.20f;
        fuelBarScale = 1;
        start = false;
    }

	void Update () {
        if (start)
        {
            
            if(fuelBarScale > 1f)
            {
                fuelBarScale = 1f;
            }
            norm = false;
            if (goingDown && Time.time > lastTime + 0.08f)
            {
                fuelBarScale = fuelBarScale - 0.004f;
                fuelBar.transform.localScale = new Vector3(fuelBarScale, fuelBar.transform.localScale.y, fuelBar.transform.localScale.z);
                fuelText.text = "Fuel: " + (int)(fuelBarScale * 100) + "%";
                lastTime = Time.time;
            }

            if (fuelBarScale <= 0)
            {
                //playerRef.transform.Find("body").GetComponent<MeshRenderer>().material = gameOverMat;
                playerRef.GetComponent<player>().forward = false;
                goingDown = false;
            }

        }
        else
        {
            if (!norm)
            {
                norm = true;
                fuelBar.transform.localScale = new Vector3(1f, fuelBar.transform.localScale.y, fuelBar.transform.localScale.z);
                //playerRef.transform.Find("body").GetComponent<MeshRenderer>().material = GetComponent<player>().mat;
                fuelBarScale = 1;
                fuelText.text = "Fuel: " + (int)(fuelBarScale * 100) + "%";
            }

        }
	}

}
