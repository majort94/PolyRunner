using UnityEngine;
using System.Collections;

public class EnergyShieldInstance : MonoBehaviour {

    public float tempA = 0.15f;
    public float maximumA = 0.3f;
    public float timer = 0f;
    public float maxTime = 1f;
    private float startTime;
    public float swingRate = 0.05f;
    
    void Start () {
        startTime = Time.time;
	}
	void Update () {
        swingAlpha();
        GetComponent<MeshRenderer>().material.color = new Color(GetComponent<MeshRenderer>().material.color.r, GetComponent<MeshRenderer>().material.color.g, GetComponent<MeshRenderer>().material.color.b, tempA);
    }
    
    void swingAlpha()
    {
        timer = Time.time - startTime;
        if (tempA < maximumA) {
            tempA += swingRate;
        } else {
            tempA -= swingRate;
        }

        if (tempA < 0.15f) {
            Destroy(gameObject);
        }
    }
}
