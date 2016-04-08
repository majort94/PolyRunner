using UnityEngine;
using System.Collections;
using UnityEngine.VR;
using UnityEngine.SceneManagement;

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

    void Start () {
        //InputTracking.Recenter();
        if (inMenu)
        {
            scaleInc = .1f;
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
                        SceneManager.LoadScene(1, LoadSceneMode.Single);
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
