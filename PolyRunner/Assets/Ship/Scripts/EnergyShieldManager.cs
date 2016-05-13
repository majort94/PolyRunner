using UnityEngine;
using System.Collections;

public class EnergyShieldManager : MonoBehaviour {

    public GameObject blueEnergyShield;
    public GameObject redEnergyShield;

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
        GameObject blueShield = (GameObject)Instantiate(blueEnergyShield, transform.position, transform.rotation);
        blueShield.transform.localPosition = new Vector3(blueShield.transform.localPosition.x + 4f, blueShield.transform.localPosition.y - 2f, blueShield.transform.localPosition.z - 4f);
        blueShield.transform.localScale = new Vector3(125, 125, 125);
        blueShield.transform.parent = GameObject.Find("/hydroplane/body").transform;

    }

    public void triggerRedShieldAnim()
    {
        // create new energy shield object (player clone, damaged texture)
        GameObject redShield = (GameObject)Instantiate(redEnergyShield, transform.position, transform.rotation);
        redShield.transform.localPosition = new Vector3(redShield.transform.localPosition.x + 4f, redShield.transform.localPosition.y - 2f, redShield.transform.localPosition.z - 4f);
        redShield.transform.localScale = new Vector3(125, 125, 125);
        redShield.transform.parent = GameObject.Find("/hydroplane/body").transform;
    }
}
