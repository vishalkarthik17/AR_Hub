using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class SpawnerScript : MonoBehaviour
{
    public GameObject[] SpawnPos;
    public GameObject prefab;


    public float currentTime = 0f;
    public float SpawnTime = 2f;
    public float decreaseSpawnTimeByLittle = 0.1f;
    public float minSpawnTime = 1f;


    
    public int gameTime;

    public GameObject Base;
    public GameObject BasePrefab;

     GameObject ButtonManagerMole;
    
    private void Start()
    {
        ButtonManagerMole = GameObject.Find("ButtonManagerMole");

    }
    void Update() 
    {
        float st = ButtonManagerMole.GetComponent<ButtonManagerMoleScript>().startTime;
        bool canstart = ButtonManagerMole.GetComponent<ButtonManagerMoleScript>().startGameflag;

       if (canstart) 
       {
            float t = Time.time - st;
            if ((gameTime - t) > 0){
                if (currentTime <= 0){
                    Spawn();
                    currentTime = SpawnTime;
                    if (SpawnTime > minSpawnTime)
                        SpawnTime = SpawnTime - decreaseSpawnTimeByLittle;
                }
                else{
                    currentTime = currentTime - Time.deltaTime;
                }
            }
        }
    }
    public void Spawn() {
        int index = Random.Range(0, 9);
        GameObject inst=Instantiate(prefab, SpawnPos[index].transform.position,transform.rotation);
        float parent = Mathf.Abs(Base.transform.localScale.x);
        float ppp = BasePrefab.transform.localScale.x;
        inst.transform.localScale = new Vector3(ppp*parent/12, ppp * parent /12, ppp * parent /12);

    }

    
    public void ReplayGame()
    {
        SceneManager.LoadScene("MoleGame");
    }

}
