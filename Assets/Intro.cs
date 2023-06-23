using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour {

    public GameObject gameObject1;

    void Start() {

    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.E)) gameObject1.SetActive(false);
    }
}
