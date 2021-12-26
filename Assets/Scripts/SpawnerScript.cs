using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class SpawnerScript : MonoBehaviour
{
    public Vector3[] SpawnPos;
    public GameObject prefab;


    public float currentTime = 0f;
    public float SpawnTime = 2f;
    public float decreaseSpawnTimeByLittle = 0.1f;
    public float minSpawnTime = 1f;

    public TextMeshProUGUI timerText;

    private float startTime;
    public int gameTime;

    public GameObject FPS_Player;
    public GameObject GOpanel;
    public TextMeshProUGUI GO_Score_Text;


    private void Start()
    {
        startTime = Time.time;
        
    }
    void Update() {
        float t = Time.time - startTime;
        string seconds = ((int)(gameTime - t)).ToString();


        if ((gameTime - t) > 0)
        {
            timerText.text = seconds;
            if (currentTime <= 0)
            {
                Spawn();
                currentTime = SpawnTime;
                if (SpawnTime > minSpawnTime)
                    SpawnTime = SpawnTime - decreaseSpawnTimeByLittle;
            }
            else
            {
                currentTime = currentTime - Time.deltaTime;
            }

        }
        else
            gameOver();
            
        
    }
    public void Spawn() {
        int index = Random.Range(0, 9);
        Instantiate(prefab, SpawnPos[index], Quaternion.identity, transform);
    }

    public void gameOver() {
        GOpanel.SetActive(true);
        int s = FPS_Player.GetComponent<Shoot>().score;
        GO_Score_Text.SetText(s.ToString());
    }
    public void ReplayGame()
    {
        SceneManager.LoadScene("MoleGame");
    }

}
