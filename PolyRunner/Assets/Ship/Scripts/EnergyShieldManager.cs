using UnityEngine;
using System.Collections;

public class EnergyShieldManager : MonoBehaviour {

    public GameObject blueEnergyShield;
    public GameObject redEnergyShield;
    
	void Start () {
	}
	
	void Update () {
	}

    public void triggerBlueShieldAnim()
    {
        // create new energy shield object (player clone, healing texture)
        Instantiate(blueEnergyShield);
    }

    public void triggerRedShieldAnim()
    {
        // create new energy shield object (player clone, damaged texture)
        Instantiate(redEnergyShield);
    }
}
