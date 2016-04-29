using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class stats : MonoBehaviour
{

    public float scoreKeep = 0f;
    public int count = 0;
    private static int i = 0;
    public int id;
    // Use this for initialization
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "main")
        {
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {

        }

        id = ++i;

    }

    // Update is called once per frame
    void Update()
    {
        if (id != i)
        {
            Destroy(gameObject);
        }
    }

}
