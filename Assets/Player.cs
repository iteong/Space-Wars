using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [Tooltip("In ms^-1")] [SerializeField] float xSpeed = 4f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffsetThisFrame = xThrow * xSpeed * Time.deltaTime;
        print(xOffsetThisFrame); // this value of m per sec * FPS should give value close to xSpeed of 4f m per sec
	}
}
