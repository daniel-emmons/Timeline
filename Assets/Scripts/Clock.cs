using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Clock : MonoBehaviour {

    public Text TimeText;
    public Text TimeScaleText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        TimeSpan timeSpan = TimeManager.Instance.GetCurrentTime();
        TimeText.text = string.Format("H:{0:00} M:{1:00} S:{2:00}", (int)timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
        TimeScaleText.text = "x" + TimeManager.Instance.TimeScale;
    }
}
