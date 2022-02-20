using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreNumber;
    public Manager mng;

    void Start() {
        mng = FindObjectOfType<Manager>();
    }

    // Update is called once per frame
    void Update() {
        scoreNumber.text = (mng.score).ToString("0");
    }
}
