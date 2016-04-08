using UnityEngine;
using System.Collections;
using UnityEngine.VR;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player : MonoBehaviour {

	// Use this for initialization
	private float speed = 250f;
	public Renderer rend;
	public Material mat;
	public bool forward = true;
    public GameObject plane;
    public bool begin = false;
	VRNode rift;
    float deadTimer= -1f;
    bool dead = false;
    public float score = 0f;
    public Text scoreText;

    private float start = -1387f;
    float strafe;

    Rigidbody rb;
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void FixedUpdate() {
        if (begin){
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
        if (forward) {
                score = start - transform.position.z;
                score = (-1 * score) / 5;
                scoreText.text = "Score: " + (int)score;
            //Vector3 move = Vector3.forward * speed;
            Vector3 move = GameObject.Find("/hydroplane/body").GetComponent<Transform>().forward * speed;
            Quaternion input = InputTracking.GetLocalRotation(rift);
            //transform.rotation = new Quaternion (0f,input.y, input.z, input.w);

            //strafe = speed * 400f;
                //strafe = strafe * input.z;
                //move = move + (strafe * Vector3.right);
                strafe = input.z * 15f;
                rb.AddForce(new Vector3(strafe, 0f, 0f), ForceMode.VelocityChange);
                //move += rb.velocity;
                // rb.velocity = new Vector3(0f, 0f, 0f);
                //rb.AddForce(Vector3.left * 200f, ForceMode.Impulse);
            if (Input.GetKey(KeyCode.A)) {
                move = move + (Vector3.left * (speed));
            }
            if (Input.GetKey(KeyCode.D)) {
                move = move + (Vector3.right * (speed));
            }

            transform.Translate(move * Time.fixedDeltaTime);
            GameObject plane = GameObject.Find("/hydroplane/Plane");
            plane.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(plane.GetComponent<Renderer>().material.mainTextureOffset.x - ((rb.velocity.x + move.x) / 65f * Time.fixedDeltaTime), plane.GetComponent<Renderer>().material.mainTextureOffset.y - ((rb.velocity.z + move.z) / 49f * Time.fixedDeltaTime));
                Debug.Log("velocity " + GetComponent<Rigidbody>().velocity);

            }
            else
            {
                if (!dead) {
                    dead = true;
                    deadTimer = Time.timeSinceLevelLoad;
                }
                else
                {
                    if(Time.timeSinceLevelLoad > (deadTimer + 2f))
                    {
                        GameObject.Find("GameManager").GetComponent<stats>().scoreKeep = score;
                        SceneManager.LoadScene(0);
                    }
                }
            }

    }

	}

}
