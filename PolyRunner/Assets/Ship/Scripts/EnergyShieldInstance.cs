using UnityEngine;
using System.Collections;

public class EnergyShieldInstance : MonoBehaviour {

    public float tempA = 0.15f;
    public float maximumA = 0.3f;
    private float timer = 0f;
    public float maxTime = 1f;
    private float startTime;
    public float swingRate = 0.05f;
    private Component[] shipPieces;
    
    void Start () {
        startTime = Time.time;
        shipPieces = GetComponentsInChildren<MeshRenderer>();
    }

	void Update () {
        //Prepare Animation
        shieldAnimation();
        //Apply Animation
        foreach (MeshRenderer shipPiece in shipPieces) {
            shipPiece.material.color = new Color(GetComponent<MeshRenderer>().material.color.r, GetComponent<MeshRenderer>().material.color.g, GetComponent<MeshRenderer>().material.color.b, tempA);
        }
        //Check End State
        endAnim();
    }

    void shieldAnimation()
    {
        timer = Time.time - startTime;
        if (tempA < maximumA) {
            tempA += swingRate;
        } else {
            tempA -= swingRate;
        }        
    }

    void endAnim()
    {
        if (tempA < 0.15f)
        {
            Destroy(gameObject);
        }
    }
}
