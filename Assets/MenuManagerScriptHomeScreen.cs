using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerScriptHomeScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadCarScene() {
        SceneManager.LoadScene("CarDriving");
    }
    public void LoadMoleGameScene()
    {
        SceneManager.LoadScene("MoleGame");
    }
}
