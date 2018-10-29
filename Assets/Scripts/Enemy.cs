using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [Tooltip("Fx prefab on player")] [SerializeField] GameObject deathFx;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnParticleCollision(GameObject other) {
        print("Particles collided with enemy" + gameObject.name);
        deathFx.SetActive(true);
        Destroy(gameObject);
    }
}
