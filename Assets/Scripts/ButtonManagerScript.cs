using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManagerScript : MonoBehaviour
{
    public static ButtonManagerScript instance;
    public bool acc1, brake1, left1, right1;
    public float scale;
    

    public GameObject scalePanel,ControlPanel;

    private void Awake()
    {
        scale = 0.5f;

        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    public void adjustScale(float newScale){
        scale = newScale;     
    }
    public void accelerate_car(bool a)
    {
        acc1 = a;
    }
    public void brake_car(bool a)
    {
        brake1 = a;
    }
    public void move_left_car(bool a)
    {
        left1 = a;
    }
    public void move_right_car(bool a)
    {
        right1 = a;
    }

    public void startDriving() {
        scalePanel.SetActive(false);
        ControlPanel.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoHome() {
        SceneManager.LoadScene("Home");
    }
}
