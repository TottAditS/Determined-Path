using System;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    private float horizontalInput, verticalInput;
    private float currentSteerAngle, currentbreakForce;
    private bool isBreaking;

    // Settings
    [SerializeField] private float motorForce, breakForce, maxSteerAngle;

    // Wheel Colliders
    [SerializeField] private WheelCollider frontLeftWheelCollider, frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider, rearRightWheelCollider;

    // Wheels
    [SerializeField] private Transform frontLeftWheelTransform, frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform, rearRightWheelTransform;

    [Header("GPS")]
    public float speed;
    public Rigidbody car;

    [Header("Steer")]
    public Transform steer;
    public float leftclamp = -150f;
    public float rightclamp = 150f;
    public float rotationspeed = 5f;
    private float InputHorizontal;
    private float steerturn;
    public bool isputer;

    [Header("UI")]
    public Scene1Eventmanager SC1UI_pause;
    public GameObject carlight;
    public bool flashlight;

    [Header("Nitro & Brake")]
    public bool Nitro;
    public int nitrovalue;
    public int brakevalue;
    public Camera displaycam;
    public Animator cameraanimator;

    [Header("UNITY DONGO DEBUG")]
    public TextMeshProUGUI debugtextunitydongo;

    private void Start()
    {
        carlight.SetActive(false);
    }

    private void Update()
    {
        Getsound();

        if (Input.GetKeyUp(KeyCode.W))
        {
            debugtextunitydongo.text = "TEKEN W";
            car.AddForce(Vector3.back * brakevalue, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            debugtextunitydongo.text = "TEKEN S";
            car.AddForce(Vector3.back * brakevalue, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            debugtextunitydongo.text = "TEKEN E";
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            flashlight = !flashlight;
            debugtextunitydongo.text = "TEKEN F";
            Getlight();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            debugtextunitydongo.text = "TEKEN Escape";
            SC1UI_pause.pausebuttonpressed = true;
        }

        //if (Input.GetKey(KeyCode.LeftShift))
        //{
        //    Nitro = true;
        //}
        //else
        //{
        //    Nitro = false;
        //}
    }

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    private void GetInput()
    {
        //for gps
        speed = car.velocity.magnitude * 3.6f;

        PowerSteerringss();

        // Steering Input
        horizontalInput = Input.GetAxis("Horizontal");

        // Acceleration Input
        verticalInput = Input.GetAxis("Vertical");

        // Breaking Input
        isBreaking = Input.GetKey(KeyCode.Space);
    }
    private void Getlight()
    {
        if (flashlight)
        {
            carlight.SetActive(true);
        }
        else
        {
            carlight.SetActive(false);
        }
    }
    private void Getsound()
    {
        if (speed < 0.1)
        {
            if (!AudioManager.instance.IsPlaying("Bus Engine Idle"))
            {
                //Debug.Log("Idle");
                AudioManager.instance.playSFX("Bus Engine Idle");
                AudioManager.instance.SFXsource.loop = true;
            }
        }

        else
        {
            AudioManager.instance.SFXsource.loop = false;

            if (Input.GetKeyDown(KeyCode.W))
            {
                //debugtextunitydongo.text = "TEKEN W";
                //Debug.Log("WWWWW");
                if (!AudioManager.instance.IsPlaying("Bus Accelerate"))
                {
                    //Debug.Log("GASKAN");
                    AudioManager.instance.playSFX("Bus Accelerate");
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            //debugtextunitydongo.text = "TEKEN S";
            if (!AudioManager.instance.IsPlaying("Bus Brake"))
            {
                AudioManager.instance.playSFX("Bus Brake");
            }
            
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            //debugtextunitydongo.text = "TEKEN E";
            if (!AudioManager.instance.IsPlaying("Bus Honk"))
            {
                AudioManager.instance.playSFX("Bus Honk");
            }
        }
    }

    private void PowerSteerringss()
    {
        if (horizontalInput != 0)
        {
            InputHorizontal = Input.GetAxis("Horizontal");
            steerturn = steerturn + (InputHorizontal * rotationspeed * speed * Time.deltaTime);
            steerturn = Mathf.Clamp(steerturn, leftclamp, rightclamp);
            steer.transform.localRotation = Quaternion.Euler(26, steerturn, 0);
        }
        else
        {
            if (steerturn > 0)
            {
                steerturn = steerturn - (speed * rotationspeed * Time.deltaTime);
            }

            if (steerturn < 0)
            {
                steerturn = steerturn + (speed * rotationspeed * Time.deltaTime);
            }

            steer.transform.localRotation = Quaternion.Euler(26, steerturn, 0);
        }
    }

    private void HandleMotor()
    {
        //jangan lupa matikan
        //if (Nitro)
        //{
        //    cameraanimator.enabled = false;
        //    car.AddForce(transform.forward * nitrovalue, ForceMode.Impulse);
        //    displaycam.fieldOfView = 70;
        //}
        //else
        //{
        //    displaycam.fieldOfView = 67;
        //}

        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;
        currentbreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();
    }

    private void ApplyBreaking()
    {
        frontRightWheelCollider.brakeTorque = currentbreakForce;
        frontLeftWheelCollider.brakeTorque = currentbreakForce;
        rearLeftWheelCollider.brakeTorque = currentbreakForce;
        rearRightWheelCollider.brakeTorque = currentbreakForce;
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);

    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
}