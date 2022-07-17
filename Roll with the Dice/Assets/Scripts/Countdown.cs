using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {
    public float countTime = 20;
    public Image timerBar;

    public float elapsedTime = 0f;

	public bool paused = true;

	
    public delegate void TimeUpCallback();
    public TimeUpCallback timeUpCallback;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		if (!paused) {
			elapsedTime += Time.deltaTime;

			timerBar.fillAmount = 1 - (elapsedTime / countTime);
			if (elapsedTime >= countTime) {
				timeUpCallback?.Invoke();
				paused = true;
			}
		}
	}

	public void Restart(TimeUpCallback callback) {
		timeUpCallback = callback;
		elapsedTime = 0;
	}
}