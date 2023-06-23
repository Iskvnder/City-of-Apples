using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundController : MonoBehaviour {

    public AudioClip musicTrack;
    private AudioSource audioSource;

    void Start() {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = musicTrack;
        audioSource.loop = true;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) {
            audioSource.Play();
        } else {
            audioSource.Pause();
        }
    }
}
