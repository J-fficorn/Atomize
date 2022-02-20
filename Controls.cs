using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {
    public bool up, down, left, right;

    void Start() {
        up = false; down = false; left = false; right = false;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey("a")) {
            up = false; down = false; left = true; right = false;
            Debug.Log("a key pressed");
        } else if (Input.GetKey("d")) {
            up = false; down = false; left = false; right = true;
            Debug.Log("d key pressed");
        } else if (Input.GetKey("w")) {
            up = transform; down = false; left = false; right = false;
            Debug.Log("w key pressed");
        } else if (Input.GetKey("s")) {
            up = false; down = true; left = false; right = false;
            Debug.Log("s key pressed");
        } else {
            up = false; down = false; left = false; right = false;
        }
    }
}