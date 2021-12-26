using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class ARTapToPlaceCar : MonoBehaviour
{
    public GameObject car;
    private GameObject spawned;
    private ARRaycastManager arRaycastManager;
    private Vector2 touchpos;
    public bool touched;
    static List<ARRaycastHit> hitlist = new List<ARRaycastHit>();
    public GameObject infplane;
    ARPlaneManager arpm;
    public GameObject canvas;
    // Start is called before the first frame update
    void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
        touched = false;
        arpm = FindObjectOfType<ARPlaneManager>();
    }

    bool TryGetTouchPosition(out Vector2 touchpos) {
        if (Input.touchCount > 0) {
            touchpos = Input.GetTouch(0).position;
            return true;
        }
        touchpos = default;
        return false;
            

    }

    // Update is called once per frame
    void Update()
    {
        if (touched == false)
        {
            if (!TryGetTouchPosition(out Vector2 touchpos))
                return;
            if (arRaycastManager.Raycast(touchpos, hitlist, TrackableType.PlaneWithinPolygon))
            {
                var hitPose = hitlist[0].pose;
                if (spawned == null)
                {
                    Object.Instantiate(infplane, hitPose.position, hitPose.rotation);
                    spawned = Instantiate(car, hitPose.position, hitPose.rotation);
                    touched = true;
                    canvas.SetActive(true);
                    foreach (var plane in arpm.trackables)
                        plane.gameObject.SetActive(false);
                }
                else
                {
                    spawned.transform.position = hitPose.position;
                }
            }
        }
        else {
            foreach (var plane in arpm.trackables)
                plane.gameObject.SetActive(false);
        }
        
    }
}
