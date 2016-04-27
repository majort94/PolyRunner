using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class fuelTimer : MonoBehaviour {

    public GameObject playerRef;
    public GameObject fuelBar;
    public Text fuelText;
    bool goingDown = true;
    float fuelBarScale = 1;
    float lastTime;
    public Material gameOverMat;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (goingDown && Time.time > lastTime + 0.5f)
        {
            fuelBarScale = fuelBarScale - 0.0005f;
            fuelBar.transform.localScale = new Vector3(fuelBarScale, fuelBar.transform.localScale.y, fuelBar.transform.localScale.z);
            fuelText.text = "Fuel: " + (int)(fuelBarScale * 100) + "%";
        }

        if (fuelBarScale <= 0)
        {
            playerRef.transform.Find("body").GetComponent<MeshRenderer>().material = gameOverMat;
            playerRef.GetComponent<player>().forward = false;
            goingDown = 0;
        }
	}

}
