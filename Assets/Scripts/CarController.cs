using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    public bool isBreaking;

    public float motorforce;
    public float breakforce;
    float currentBreakForce;

    float currentsteerAngle;
    public float maxSteerAngle;

    public WheelCollider frontLeftWheelCollider;
    public WheelCollider frontRightWheelCollider;
    public WheelCollider rearLeftWheelCollider;
    public WheelCollider rearRightWheelCollider;

    public Transform frontLeftWheelTransform;
    public Transform frontRightWheelTransform;
    public Transform rearLeftWheelTransform;
    public Transform rearRightWheelTransform;


    public bool acc, brake, left, right;
    public float carscale;

    GameObject ButtonManager;

    private void Start(){
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        ButtonManager = GameObject.Find("ButtonManager");
        carscale = 0.5f;
    }
    

    private void FixedUpdate()
    {
        acc = ButtonManager.GetComponent<ButtonManagerScript>().acc1;
        brake = ButtonManager.GetComponent<ButtonManagerScript>().brake1;
        left = ButtonManager.GetComponent<ButtonManagerScript>().left1;
        right = ButtonManager.GetComponent<ButtonManagerScript>().right1;

        carscale = ButtonManager.GetComponent<ButtonManagerScript>().scale;
        Debug.Log(carscale);
        this.transform.localScale = new Vector3(carscale, carscale, carscale);

        if ((acc == true && brake == true) || (acc == false && brake == false))
            verticalInput = 0f;
        else if (acc == true)
            verticalInput = 1.0f;
        else if (brake == true)
            verticalInput = -1.0f;

        if ((left == true && right == true) || (left == false && right == false))
            horizontalInput = 0f;
        else if (left == true)
            horizontalInput = -1.0f;
        else if (right == true)
            horizontalInput = 1.0f;

        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }
    private void HandleMotor() {
        
            rearLeftWheelCollider.motorTorque = -verticalInput * motorforce;
            rearRightWheelCollider.motorTorque = -verticalInput * motorforce;
    }

    private void HandleSteering() {
        currentsteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentsteerAngle;
        frontRightWheelCollider.steerAngle = currentsteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform WheelTransform) {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        WheelTransform.position = pos;
        WheelTransform.rotation = rot;
    }
}
