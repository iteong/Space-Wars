using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [Tooltip("In ms^-1")] [SerializeField] float speed = 20f;
    [Tooltip("In m")] [SerializeField] float xRange = 8f;
    [Tooltip("In m")] [SerializeField] float yRange = 4.5f;

    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float positionYawFactor = 6.5f;
    [SerializeField] float controlRollFactor = -30f;

    float xThrow, yThrow;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        // change pitch due to position and control throw
        float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll); // x = pitch, y = yaw, z = roll
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        // this value of m per sec * FPS should give value close to xSpeed of 4f m per sec
        float xOffset = xThrow * speed * Time.deltaTime;
        float yOffset = yThrow * speed * Time.deltaTime;

        float rawNewXPos = transform.localPosition.x + xOffset;
        float clampedNewXPos = Mathf.Clamp(rawNewXPos, -xRange, xRange);

        float rawNewYPos = transform.localPosition.y + yOffset;
        float clampedNewYPos = Mathf.Clamp(rawNewYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedNewXPos, clampedNewYPos, transform.localPosition.z);
    }
}
