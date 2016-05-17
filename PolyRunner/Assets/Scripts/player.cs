using UnityEngine;
using System.Collections;
using UnityEngine.VR;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player : MonoBehaviour {

	// Use this for initialization
	public float speed = 225f;
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

    public GameObject shipReference;

    float strafe;

    // Variables for rotation movement
    private bool overTilt = false;
    private bool overTilt2 = false;
    private float tiltStamp = 0f;

    public Material gameOverMat;

    public GameObject health;

    Rigidbody rb;

    private float deathPause;
    private bool firstHit = false;


	void Start () {
        rb = GetComponent<Rigidbody>();
        //shipReference.GetComponent<EnergyShieldManager>().triggerBlueShieldAnim();
    }

    // Update is called once per frame
    void FixedUpdate() {
        //shipReference.GetComponent<EnergyShieldManager>().triggerBlueShieldAnim();
        Quaternion input = InputTracking.GetLocalRotation(rift);
        //Debug.Log("z " + input.z);
        if (begin){
            if (transform.Find("body").Find("sand")) {
                transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
                if (!transform.Find("body").Find("sand").GetComponent<ParticleSystem>().isPlaying)
                {
                    transform.Find("body").Find("sand").GetComponent<ParticleSystem>().Play();
                }
            }
                

        if (forward) {
                GetComponent<fuelTimer>().start = true;
                if (transform.position.z % 1800 == 0)
                { 
                Instantiate(health);
                Instantiate(health);
                }
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
                strafe = input.z * 2000f * Time.fixedDeltaTime;
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
                GameObject.Find("/hydroplane/PlaneSand").GetComponent<Renderer>().material.mainTextureOffset = new Vector2(plane.GetComponent<Renderer>().material.mainTextureOffset.x - ((rb.velocity.x + move.x) / 65f * Time.fixedDeltaTime), plane.GetComponent<Renderer>().material.mainTextureOffset.y - ((rb.velocity.z + move.z) / 49f * Time.fixedDeltaTime));
                GameObject.Find("/hydroplane/PlaneSand1").GetComponent<Renderer>().material.mainTextureOffset = new Vector2(plane.GetComponent<Renderer>().material.mainTextureOffset.x - ((rb.velocity.x + move.x) / 65f * Time.fixedDeltaTime), plane.GetComponent<Renderer>().material.mainTextureOffset.y - ((rb.velocity.z + move.z) / 49f * Time.fixedDeltaTime));
                GameObject.Find("/hydroplane/PlaneSand2").GetComponent<Renderer>().material.mainTextureOffset = new Vector2(plane.GetComponent<Renderer>().material.mainTextureOffset.x - ((rb.velocity.x + move.x) / 65f * Time.fixedDeltaTime), plane.GetComponent<Renderer>().material.mainTextureOffset.y - ((rb.velocity.z + move.z) / 49f * Time.fixedDeltaTime));
                //Debug.Log("velocity " + GetComponent<Rigidbody>().velocity);

            }
            else
            {
                
                if (!dead) {
                    dead = true;
                    deadTimer = Time.timeSinceLevelLoad;
                    rb.velocity = Vector3.zero;
                    //transform.Find("body").Find("sand").GetComponent<ParticleSystem>().Pause();
                    //transform.Find("body").Find("sand").GetComponent<ParticleSystem>().Clear();
                    Destroy(transform.Find("body").Find("sand").gameObject);
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

	} // end fixed Update

    void OnTriggerEnter(Collider col)
    {
        //if (col.gameObject.CompareTag("obstacles"))
        // {
        //if (!hit)
        // {
       // Debug.Log("hit");
        if (col.isTrigger)
        {
            //Debug.Log("hit2");
            return;
        }

        if (col.gameObject.layer == 12)
        {
            //Debug.Log("health");
            col.gameObject.GetComponent<fuel>().activate();
            GetComponent<fuelTimer>().pickup();
            //firstHit = false;

            shipReference.GetComponent<EnergyShieldManager>().triggerBlueShieldAnim();
            return;
        }

        // if (GameObject.Find("GameManager").GetComponent<stats>().count > 3)
        if (col.gameObject.layer == 11)
        {

            /*
            if (firstHit && (Time.time > (deathPause + .2f)))
            {
                forward = false;
                GetComponent<fuelTimer>().start = true;
                return;

            }
            
                firstHit = true;
                */
            //deathPause = Time.time;
            // transform.Find("body").GetComponent<MeshRenderer>().material = gameOverMat;
            //GetComponent<fuelTimer>().start = true;
            transform.Find("body").gameObject.GetComponent<badHit>().hit();
            //Destroy(col.gameObject);
            GetComponent<fuelTimer>().onHit();
            shipReference.GetComponent<EnergyShieldManager>().triggerRedShieldAnim();
            // Instantiate(health);
            //   Instantiate(health);
        }
        else
        {
            forward = false;
            transform.Find("body").GetComponent<MeshRenderer>().material = gameOverMat;
        }

        //GameObject.Find("/hydroplane/body").transform.parent = null;
        //   hit = true;
        // }
        //  }
    }

    }
