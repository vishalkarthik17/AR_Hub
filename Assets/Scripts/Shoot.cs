using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shoot : MonoBehaviour
{
    public GameObject MainCam;

    public int score;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        var ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hitObj;
        if (Physics.Raycast(ray, out hitObj)) 
        {
            var selection = hitObj.transform;
            Debug.Log(hitObj.transform.name);
            if (selection.CompareTag("Mole")) {
                Destroy(hitObj.transform.gameObject);
                score++;
            }

            scoreText.SetText(score.ToString());
        }
    }
}
