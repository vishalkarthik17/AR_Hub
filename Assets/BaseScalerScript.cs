using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScalerScript : MonoBehaviour
{
    public float baseScale;
    GameObject ButtonManagerMole;
    private void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        ButtonManagerMole = GameObject.Find("ButtonManagerMole");
        baseScale = 0.1f;
        this.transform.localScale = new Vector3(baseScale, baseScale, baseScale);
    }
    private void FixedUpdate() {
        baseScale = ButtonManagerMole.GetComponent<ButtonManagerMoleScript>().scale;
        this.transform.localScale = new Vector3(baseScale, baseScale, baseScale);

    }
}
