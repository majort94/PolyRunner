using UnityEngine;
using System.Collections;
using UnityEngine.VR;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player : MonoBehaviour {

	// Use this for initialization
	private float speed = 225f;
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

    float strafe;

    // Variables for rotation movement
    private bool overTilt = false;
    private bool overTilt2 = false;
    private float tiltStamp = 0f;

    Rigidbody rb;
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void FixedUpdate() {
        Quaternion input = InputTracking.GetLocalRotation(rift);
        //Debug.Log("z " + input.z);
        if (begin){
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
        if (forward) {
                score = transform.position.z / 5;
                scoreText.text = "Score: " + (int)score;
            //Vector3 move = Vector3.forward * speed;
            Vector3 move = GameObject.Find("/hydroplane/body").GetComponent<Transform>().forward * speed;
                move = Vector3.zero;
                //transform.rotation = new Quaternion (0f,input.y, input.z, input.w);


                // Rotation stuff

                //strafe = speed * 400f;
                //strafe = strafe * input.z;
                //move = move + (strafe * Vector3.right);
                //Debug.Log("tilt " + input.z);
                bool test = true;
                if (Mathf.Abs(input.z) > .05f)
                {
                    overTilt = true;
                    tiltStamp = input.z;
                    if (overTilt2)
                    {
                        overTilt2 = false;
                    }
                }
                
                if (overTilt)
                {
                    if (test)
                    {

                        if ((Mathf.Abs(input.z) < .05f) && !overTilt2)
                        {
                            Vector3 newVelocity = rb.velocity * .7f;
                            rb.velocity = newVelocity;
                            //overTilt = false;
                            overTilt2 = true;
                            //Debug.Log("speed change1");

                        }

                        /* if ((Mathf.Abs(input.z) < .01f) && overTilt2)
                         {
                             Vector3 newVelocity = rb.velocity * .65f;
                             rb.velocity = newVelocity;
                             overTilt = false;
                             overTilt2 = false;
                             Debug.Log("speed change2");
                         }
                         */
                        if (((input.z) < -.02f) && ((tiltStamp) > 0f) && overTilt2)
                        {
                            Vector3 newVelocity = rb.velocity * .7f;
                            rb.velocity = newVelocity;
                            overTilt = false;
                            overTilt2 = false;
                           // Debug.Log("speed change2");
                        }

                        if (((input.z) > .02f) && ((tiltStamp) < 0f) && overTilt2)
                        {
                            Vector3 newVelocity = rb.velocity * .7f;
                            rb.velocity = newVelocity;
                            overTilt = false;
                            overTilt2 = false;
                        //    Debug.Log("speed change2");
                        }
                    }
                    else
                    {
                        if ((Mathf.Abs(input.z) < .03f))
                        {
                            Vector3 newVelocity = rb.velocity /  1.6f;
                            rb.velocity = newVelocity;
                            overTilt = false;
                            //overTilt2 = true;
                            //Debug.Log("speed change1");

                        }
                    }
                } //2400
                strafe = input.z * 2400f * Time.fixedDeltaTime;
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

            //transform.Translate(move * Time.fixedDeltaTime);
            GameObject plane = GameObject.Find("/hydroplane/Plane");
                rb.velocity = new Vector3(rb.velocity.x, 0f, 400f);
                if (rb.velocity.x > 500f)
                {
                    rb.velocity = new Vector3(500f, 0f, 500f);
                }

                if (rb.velocity.x < -500f)
                {
                    rb.velocity = new Vector3(-500f, 0f, 500f);
                }
                plane.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(plane.GetComponent<Renderer>().material.mainTextureOffset.x - ((rb.velocity.x + move.x) / 65f * Time.fixedDeltaTime), plane.GetComponent<Renderer>().material.mainTextureOffset.y - ((rb.velocity.z + move.z) / 49f * Time.fixedDeltaTime));
                //Debug.Log("velocity " + GetComponent<Rigidbody>().velocity);

            }
            else
            {
                if (!dead) {
                    dead = true;
                    deadTimer = Time.timeSinceLevelLoad;
                    rb.velocity = Vector3.zero;
                }
                else
                {
                    if(Time.timeSinceLevelLoad > (deadTimer + 1f))
                    {
                        GameObject.Find("GameManager").GetComponent<stats>().scoreKeep = score;
                        SceneManager.LoadScene(0);
                    }
                }
            }

    }

	}

}
