using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class menuCode : MonoBehaviour {

    // Use this for initialization
    public Text scoreText;
	void Start () {
        scoreText.text = "Score: " + (int) GameObject.Find("GameManager").GetComponent<stats>().scoreKeep;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
