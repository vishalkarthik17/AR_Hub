using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
[RequireComponent(typeof(ARRaycastManager))]
public class Shoot : MonoBehaviour
{
    public Camera MainCam;

    public int score;
    public TextMeshProUGUI scoreText;

    private ARRaycastManager arRaycastManager;
    static List<ARRaycastHit> hitlist = new List<ARRaycastHit>();

    public ParticleSystem muzzleFlash;
    public ParticleSystem BurstPart;
    void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void ShootBullet() {
        muzzleFlash.Play();
        var ray = MainCam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hitObj;
        if (Physics.Raycast(ray, out hitObj))
        {
            var selection = hitObj.transform;
            if (selection.CompareTag("Mole"))
            {
                Destroy(hitObj.transform.gameObject);
                Instantiate(BurstPart, hitObj.transform.position, Quaternion.identity);
                //BurstPart.transform.localScale = hitObj.transform.localScale;
                BurstPart.Play();
                score++;
            }

            scoreText.SetText(score.ToString());
        }
    }
}
