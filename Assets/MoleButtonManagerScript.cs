using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleButtonManagerScript : MonoBehaviour
{
    public static MoleButtonManagerScript instance;
    public float scale;

    public GameObject scalePanel, ControlPanel;

    private void Awake()
    {
        scale = 0.5f;

        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    public void adjustScale(float newScale)
    {
        scale = newScale;
    }
    

    public void startDriving()
    {
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
}
