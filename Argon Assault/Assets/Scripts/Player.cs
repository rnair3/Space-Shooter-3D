using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("m/s")][SerializeField] float xSpeed = 4f;
    [Tooltip("m")] [SerializeField] float xRange = 5f;
    [Tooltip("m")] [SerializeField] float yRange = 3f;
    [SerializeField] GameObject[] guns;

    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float positionYawFactor = 5f;
    [SerializeField] float controlRollFactor = -20f;

    private float horizontalThrow, verticalThrow;

    bool enableControl = true;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enableControl)
        {
            Translate();
            Rotate();
            Shoot();
        }

    }

    private void Shoot()
    {
        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            ActivateDeactivateGuns(true);
        }
        else
        {
            ActivateDeactivateGuns(false);
        }
    }

    private void ActivateDeactivateGuns(bool isEnable)
    {
        foreach (GameObject gun in guns)
        {
            var emission = gun.GetComponent<ParticleSystem>().emission;
            emission.enabled = isEnable; 
        }
    }

    private void Rotate()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + verticalThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = horizontalThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void Translate()
    {
        horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        verticalThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = horizontalThrow * xSpeed * Time.deltaTime;
        float yOffset = verticalThrow * xSpeed * Time.deltaTime;

        transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x + xOffset, -xRange, xRange),
                                            Mathf.Clamp(transform.localPosition.y + yOffset, -yRange, yRange),
                                            transform.localPosition.z);
    }


    void PlayerDeath()
    {
        enableControl = false;
    }
}
