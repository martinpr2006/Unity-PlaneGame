using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float FlySpeed = 10f;
    public float YawAmount = 120f;
    public float PitchAmount = 50f;
    public float RollAmount = 90f;
    public float RotationSpeed = 3f;
    
    private float yaw;
    private float pitch;
    private float roll;
    private float currentPitch;
    private float currentRoll;
    
    void Start()
    {
        
    }

    void Update()
    {
        transform.position += transform.forward * FlySpeed * Time.deltaTime;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        yaw += horizontalInput * YawAmount * Time.deltaTime;
        
        float targetPitch = verticalInput * PitchAmount;
        float targetRoll = -horizontalInput * RollAmount;
        
        currentPitch = Mathf.Lerp(currentPitch, targetPitch, RotationSpeed * Time.deltaTime);
        currentRoll = Mathf.Lerp(currentRoll, targetRoll, RotationSpeed * Time.deltaTime);

        transform.localRotation = Quaternion.Euler(currentPitch, yaw, currentRoll);
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Danger"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}