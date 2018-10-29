using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // ok as long as this is the only script loading scenes

public class CollisionHandler : MonoBehaviour {

    // todo work out why sometimes slow on first play of scene
    [Tooltip("In seconds")][SerializeField] float levelLoadDelay = 1f;
    [Tooltip("Fx prefab on player")][SerializeField] GameObject deathFx;

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        deathFx.SetActive(true);
        Invoke("ReloadScene", levelLoadDelay);
    }

    private void StartDeathSequence()
    {
        print("Player dying");
        SendMessage("OnPlayerDeath");
    }

    private void ReloadScene() {
        SceneManager.LoadScene(1);
    }
}
