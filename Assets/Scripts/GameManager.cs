using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> {

    public TimelineState timelineState = TimelineState.Active;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

public enum TimelineState
{
    Disabled,
    Active,
    Paused,
    FastForward,
    Rewind
}

public enum GameState
{
    
}