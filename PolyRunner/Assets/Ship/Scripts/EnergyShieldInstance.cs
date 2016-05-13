using UnityEngine;
using System.Collections;

public class EnergyShieldInstance : MonoBehaviour {

    private float tempA = 0.0f;
    private float maximumA = 0.15f;
    private float timer = 0f;
    private float maxTime = 1f;
    private float startTime;
    private float swingRate = 0.03f;
    private Component[] shipPieces;
    private float lastTime;
    private int swingDirection = 0;
    
    void Start () {
        startTime = Time.time;
        shipPieces = GetComponentsInChildren<MeshRenderer>();
        lastTime = Time.time;
        foreach (MeshRenderer shipPiece in shipPieces)
        {
            shipPiece.material.color = new Color(shipPiece.material.color.r, shipPiece.material.color.g, shipPiece.material.color.b, 0f);
        }
    }

	void Update () {
        //Prepare Animation
        shieldAnimation();
        //Apply Animation
        foreach (MeshRenderer shipPiece in shipPieces) {
            shipPiece.material.color = new Color(shipPiece.material.color.r, shipPiece.material.color.g, shipPiece.material.color.b, tempA);
        }
        //Check End State
        endAnim();
    }

    void shieldAnimation()
    {
        if (Time.time > lastTime + 0.02f) {
            switch(swingDirection) {
                case 0:
                    tempA += swingRate;
                    if (tempA >= 0.3f) { swingDirection = 1; }
                    break;
                case 1:
                    tempA -= swingRate;
                    if (tempA <= 0.0f) { swingDirection = 0; }
                    break;
                default:
                    break;
            }
            lastTime = Time.time;
        }
    }

    void endAnim()
    {
        if (Time.time > startTime + 2f)
        {
            Destroy(gameObject);
        }
    }
}
