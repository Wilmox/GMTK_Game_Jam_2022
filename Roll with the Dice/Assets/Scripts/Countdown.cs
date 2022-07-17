using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {
    public float countTime = 60;
    public Image timerBar;

    float elapsedTime = 0f;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        elapsedTime += Time.deltaTime;

        timerBar.fillAmount = 1 - (elapsedTime / countTime);
	}
}