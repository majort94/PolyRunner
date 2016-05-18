using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Oculus.Platform;
using UnityEngine.UI;

public class stats : MonoBehaviour
{

    public float scoreKeep = 0f;
    public int count = 0;
    private static int i = 0;
    public int id;
    //private static string appID = "1010185132369368";

    
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

        id = i++;

        if(id == 0)
        {
            // Oculus.Platform.Core.Initialize(Oculus.Platform.PlatformSettings.AppID);
           // int temp = PlayerPrefs.GetInt("score");
            


            //Oculus.Platform.Entitlement.IsUserEntitledToApplication().OnComplete(callbackMethod);
        }

    }

    // Update is called once per frame
    void Update()
    {
       Request.RunCallbacks();
    }

    void OnLevelWasLoaded(int level)
    {

        // Debug.Log("board " +  r.ToString());

        // MessageWithLeaderboardEntries list = //r.;

        // int m = Message.Deserialize<int>();


        if (id != 0)
        {
            Destroy(gameObject);
        }

        if(level == 0)
        {

            int size = PlayerPrefs.GetInt("boardSize");
            Debug.Log("size " + size);

            if (size < 5)
            {
                size++;
                Debug.Log("sizee " + size);
                PlayerPrefs.SetFloat("score" + size.ToString(), scoreKeep);
                PlayerPrefs.SetString("date" + size.ToString(), System.DateTime.Today.ToShortDateString().Remove(4) + System.DateTime.Now.Year.ToString().Substring(2));
                PlayerPrefs.SetInt("boardSize", size);
                PlayerPrefs.Save();
                //Debug.Log("score " + PlayerPrefs.GetFloat("score" + size.ToString()));
                //Debug.Log("haskey " + PlayerPrefs.HasKey("score1"));

                for (int i = size; i > 0; i--)
                {
                    if (PlayerPrefs.GetFloat("score" + i.ToString()) > PlayerPrefs.GetFloat("score" + (i - 1).ToString()))
                    {
                        PlayerPrefs.SetFloat("temp", PlayerPrefs.GetFloat("score" + (i - 1).ToString()));
                        PlayerPrefs.SetString("tempDate", PlayerPrefs.GetString("date" + (i - 1).ToString()));

                        PlayerPrefs.SetFloat("score" + (i - 1).ToString(), PlayerPrefs.GetFloat("score" + i.ToString()));
                        PlayerPrefs.SetString("date" + (i - 1).ToString(), PlayerPrefs.GetString("date" + i.ToString()));
                        PlayerPrefs.SetFloat("score" + i.ToString(), PlayerPrefs.GetFloat("temp"));
                        PlayerPrefs.SetString("date" + i.ToString(), PlayerPrefs.GetString("tempDate"));
                        PlayerPrefs.Save();
                    }
                }

            }
            else
            {
                for(int i = 1; i < 6; i++)
                {
                    if(scoreKeep > PlayerPrefs.GetFloat("score" + i.ToString()))
                    {
                        PlayerPrefs.SetFloat("temp", PlayerPrefs.GetFloat("score" + i.ToString()));
                        PlayerPrefs.SetString("tempDate", PlayerPrefs.GetString("date" + i.ToString()));
                        PlayerPrefs.SetFloat("score" + i.ToString(), scoreKeep);
                        PlayerPrefs.SetString("date" + i.ToString(), System.DateTime.Today.ToShortDateString().Remove(4) + System.DateTime.Now.Year.ToString().Substring(2));

                        for (int j = i; j < 5; j++)
                        {
                                PlayerPrefs.SetFloat("temp", PlayerPrefs.GetFloat("score" + j.ToString()));
                                PlayerPrefs.SetFloat("score" + j.ToString(), PlayerPrefs.GetFloat("temp"));
                                PlayerPrefs.Save();
                        }

                        break;
                    }
                }
            }

            //Debug.Log("time " + System.DateTime.Today.ToShortDateString().Remove(4) + System.DateTime.Now.Year.ToString().Substring(2));

            for (int i = 1; i <= size; i++)
            {
                // Debug.Log("score" + i.ToString() + " " + PlayerPrefs.GetFloat("score" + i.ToString()));
                GameObject.Find("/Canvas/table/" + i.ToString() + "/score").GetComponent<Text>().text = PlayerPrefs.GetFloat("score" + i.ToString()).ToString();
                GameObject.Find("/Canvas/table/" + i.ToString() + "/date").GetComponent<Text>().text = PlayerPrefs.GetString("date" + i.ToString());

            }
            //Leaderboards.WriteEntry("TestBoard", (long)scoreKeep);
            //Leaderboards.

            //Oculus.Platform.Leaderboards
            Oculus.Platform.LeaderboardFilterType a = LeaderboardFilterType.None;
            //Request<Oculus.Platform.Models.LeaderboardEntryList> m = Leaderboards.GetEntries("TestBoard", 1, LeaderboardFilterType.None, LeaderboardStartAt.Top);


            //CAPI.ovr_Message_GetString(m);
            //CAPI.ovr_Message_GetLeaderboardEntryArray();

            //Request<Oculus.Platform.Models.LeaderboardEntryList> m = Request<Oculus.Platform.Models.LeaderboardEntryList>.;

            //MessageWithLeaderboardEntries.Deserialize<Oculus.Platform.Models.LeaderboardEntryList>(m);
            //Oculus.Platform.Models.LeaderboardEntryList list = Oculus.Platform.Models.LeaderboardEntryList;

            //MessageWithLeaderboardEntries m2 = m;

           // Leaderboards.GetLeaderboardEntryList();

            
            //Debug.Log("dataaaaa " + m.GetLeaderboardEntryList());
            // var message = CAPI.ovr_Message_GetString(m);
           // ulong m1 = Oculus.Platform.CAPI.ovr_Leaderboard_GetEntries("TestBoard", 1, a, LeaderboardStartAt.Top);
            

           // Debug.Log("dispolay " + m1);
        }
    }



    void callbackMethod(Oculus.Platform.Message msg)
    {
        if (!msg.IsError)
        {
            // Entitlement check passed
        }
        else
        {
            // Entitlement check failed
            Debug.Log("App Entitlement Fail");
        }
    }

}

