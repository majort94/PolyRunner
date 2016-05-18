using UnityEngine;
using System.Collections;

public class EnergyShieldManager : MonoBehaviour {

    public GameObject blueEnergyShield;
    public GameObject redEnergyShield;
    public GameObject constantRedShield;

    private bool first = true;

    private float startTime;
    
	void Start () {
        startTime = Time.time;
	}
	
	void Update () {
	}

    public void triggerBlueShieldAnim()
    {
        // create new energy shield object (player clone, healing texture)
        //GameObject blueShield = (GameObject) Instantiate(blueEnergyShield, transform.position, transform.rotation);
        Vector3 newPos = new Vector3(transform.position.x, 0f, transform.position.z);
        GameObject blueShield = (GameObject)Instantiate(blueEnergyShield, newPos, transform.rotation);

        blueShield.transform.localScale = new Vector3(128, 128, 128);
        blueShield.transform.parent = GameObject.Find("/hydroplane/body").transform;
        blueShield.transform.localPosition = new Vector3(blueShield.transform.localPosition.x + 49f, blueShield.transform.localPosition.y - 18f, blueShield.transform.localPosition.z - 39f);

    }

    public void triggerRedShieldAnim()
    {
        // create new energy shield object (player clone, damaged texture)
        Vector3 newPos = new Vector3(transform.position.x, 0f, transform.position.z);
        GameObject redShield = (GameObject)Instantiate(redEnergyShield, newPos, transform.rotation);
        constantRedShield.SetActive(true);
        
        redShield.transform.localScale = new Vector3(128, 128, 128);
        redShield.transform.parent = GameObject.Find("/hydroplane/body").transform;
        redShield.transform.localPosition = new Vector3(redShield.transform.localPosition.x + 49f, redShield.transform.localPosition.y - 18f, redShield.transform.localPosition.z - 39f);
    }
}
