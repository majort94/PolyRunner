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
        if (first && (Time.time > startTime + 3f))
        {
            triggerBlueShieldAnim();
            first = false;
        }
	}

    public void triggerBlueShieldAnim()
    {
        // create new energy shield object (player clone, healing texture)
        GameObject blueShield = (GameObject) Instantiate(blueEnergyShield, transform.position, transform.rotation);
        blueShield.transform.localScale = new Vector3(109, 109, 109);
    }

    public void triggerRedShieldAnim()
    {
        // create new energy shield object (player clone, damaged texture)
        Instantiate(redEnergyShield, transform.position, transform.rotation);
    }
}
