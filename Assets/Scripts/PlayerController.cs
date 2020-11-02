using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("General")]
    [Tooltip("In [m/s]")] [SerializeField] float xSpeed = 10f;
    [Tooltip("In [m/s]")] [SerializeField] float xMaxOffset = 5f;
    [Tooltip("In [m/s]")] [SerializeField] float ySpeed = 10f;
    [Tooltip("In [m/s]")] [SerializeField] float yMaxOffset = 3f;

    [Header("Screen-Position Based")]   
    [SerializeField] float positionPitchFactor = -6f;
    [SerializeField] float positionYawFactor = 6f;

    [Header("Control-Throw Based")]
    [SerializeField] float controlPitchFactor = -15f;
    [SerializeField] float controllRollFactor = -25;

    bool isControlEnabled = true;

    float horizontalThrow, verticalThrow;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
        }
    }


    private void ProcessTranslation()
    {
         horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = horizontalThrow * xSpeed * Time.deltaTime;
        xOffset = Mathf.Clamp(xOffset + transform.localPosition.x, -xMaxOffset, xMaxOffset);

        verticalThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = verticalThrow * ySpeed * Time.deltaTime;
        yOffset = Mathf.Clamp(yOffset + transform.localPosition.y, -yMaxOffset, yMaxOffset);

        transform.localPosition = new Vector3(xOffset, yOffset, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + verticalThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = horizontalThrow * controllRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void OnPlayerDeath() // called by string reference
    {
        isControlEnabled = false;
    }
}
