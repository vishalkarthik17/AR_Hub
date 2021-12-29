using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonManagerMoleScript : MonoBehaviour
{
    public static ButtonManagerMoleScript instance;
    public float scale;

    public GameObject scalePanel, ControlPanel;

    
    public bool startGameflag;

    public float startTime = 0f;

    private void Awake()
    {
      
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    public void adjustScale(float newScale)
    {
        scale = newScale;
        
    }
    

    public void startGame()
    {
        scalePanel.SetActive(false);
        ControlPanel.SetActive(true);
        startGameflag = true;
        startTime = Time.time;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GoHome()
    {
        SceneManager.LoadScene("Home");
    }
}
