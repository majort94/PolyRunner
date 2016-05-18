using UnityEngine;
using System.Collections;
using UnityEngine.VR;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class cursor : MonoBehaviour {

    // Use this for initialization

    public Ray ray;
    RaycastHit hit;
    Collider col;
    public GameObject butt;
    public GameObject sphere;
    private bool onHit = false;
    private float scaleInc = 2.5f;
    public GameObject player;
    LayerMask ui;
    public GameObject cursor1;
    public bool uiPoll = true;
    public Camera cam;
    public bool inMenu = false;

    public GameObject[] screens;
    private GameObject mainScreen;
    public GameObject backButtonFix;

    void Start () {
        //InputTracking.Recenter();
        if (inMenu)
        {
            scaleInc = .1f;

            mainScreen = screens[0];
            if (GameObject.Find("GameManager"))
            {
                //Debug.Log("found");
                //scoreText.text = "Score: " + (int) GameObject.Find("GameManager").GetComponent<stats>().scoreKeep;
                screens[0].SetActive(false);
                screens[4].SetActive(true);
                screens[4].transform.Find("score").GetComponent<Text>().text = ((int)GameObject.Find("GameManager").GetComponent<stats>().scoreKeep).ToString();
                mainScreen = screens[4];
            }

        }

    }

    // Update is called once per frame
    void Update() {
        if (uiPoll) {
            ray = cam.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            if (Physics.Raycast(ray, out hit, 1000.0F, LayerMask.GetMask("UI"))) {
                //Debug.Log("hit " + hit.collider.gameObject);
                onHit = true;
            }
            else
            {
                onHit = false;
                sphere.transform.localScale = new Vector3(190f, 150f, 150f);
                if (inMenu)
                {
                    sphere.transform.localScale = new Vector3(10f, 10f, 10f);
                }
            }
            //Debug.DrawLine(ray.origin, ray.GetPoint(800));
            //Debug.Log("uipoll " + uiPoll);

            if (onHit)
            {
                sphere.transform.localScale -= new Vector3(scaleInc, scaleInc, scaleInc);
                if ((!inMenu && sphere.transform.localScale.x <= 50f) || (inMenu && sphere.transform.localScale.x <= 3f))
                {
                    if (inMenu)
                    {
                        string hitBox = hit.transform.name;
                        switch (hitBox) {
                            case "StartGameButton":
                            case "TryAgainButton":
                                SceneManager.LoadScene(1, LoadSceneMode.Single);
                                break;
                            case "InstructionsButton":
                                mainScreen.SetActive(false); 
                                screens[1].SetActive(true);
                                break;
                            case "BackButton1":
                                mainScreen.SetActive(true);
                                screens[1].SetActive(false);
                                break;
                            case "LeaderboardButton":
                                mainScreen.SetActive(false);
                                screens[2].SetActive(true);
                                backButtonFix.SetActive(true);
                                break;
                            case "BackButton2":
                                mainScreen.SetActive(true);
                                screens[2].SetActive(false);
                                backButtonFix.SetActive(false);
                                break;
                            case "CreditsButton":
                                mainScreen.SetActive(false);
                                screens[3].SetActive(true);
                                break;
                            case "BackButton3":
                                mainScreen.SetActive(true);
                                screens[3].SetActive(false);
                                break;
                            case "ExitGameButton":
                                Application.Quit();
                                break;
                            default:
                                break;
                         }
                        return;
                    }
                    player.GetComponent<player>().begin = true;
                    sphere.SetActive(false);
                    cursor1.SetActive(false);
                    uiPoll = false;
            }
            }

        }
    }
}
