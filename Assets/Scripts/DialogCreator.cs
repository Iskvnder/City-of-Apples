using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogCreator : MonoBehaviour {

    private SoundText soundText;
    private Intro intro;

    private void Start() {
        soundText = FindFirstObjectByType<SoundText>();
        intro = FindFirstObjectByType<Intro>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            soundText.GetRandomDialog();
            if (intro != null) {
                intro.gameObject.SetActive(false);
            }
        }
    }
}
