using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameMetricsManagerScript : MonoBehaviour
{
   
    public int gameTime;
    public TextMeshProUGUI timerText;

    public GameObject Cam;
    public GameObject GOpanel;
    public TextMeshProUGUI GO_Score_Text;

    public GameObject ButtonManagerMole;

    public GameObject shootControlPanel;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float st = ButtonManagerMole.GetComponent<ButtonManagerMoleScript>().startTime;
        bool canstart = ButtonManagerMole.GetComponent<ButtonManagerMoleScript>().startGameflag;
        if (canstart)
        {
            float t = Time.time - st;
            string seconds = ((int)(gameTime - t)).ToString();

            if ((gameTime - t) > 0)
            {
                timerText.SetText(seconds.ToString());
            }
            else
            {
                gameOver();
            }
        }
    }
    public void gameOver()
    {
        GOpanel.SetActive(true);
        int s = Cam.GetComponent<Shoot>().score;
        GO_Score_Text.SetText(s.ToString());
        shootControlPanel.SetActive(false);
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene("MoleGame");
    }
}
