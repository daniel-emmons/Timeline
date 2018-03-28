using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimelineManager : MonoBehaviour {



    //18 hours = 1080 minutes just using this as a placeholder
    //These are used to define which step is where gametime starts and ends
    int beginningTimeStep = 0;
    int endingTimeStep = 1080;

    //Time in seconds between each step
    float timePerStep = 1f;
    float currentTimePassed; //temp var used to count microseconds

    //How many in game minutes should pass per step?
    int gameMinutesPerStep = 5;

    //what hour does the timeline start at?
    int startingTime = 6;
    
    //Holds which step we are currently at.  
    int currentStep = 0;

    //Current time in hours and minutes
    [SerializeField]
    int currentHours = 6;
    [SerializeField]
    int currentMinutes = 0;

    //Whether or not the timeline is active. NOTE: This is not used for pausing the timeline.
    bool timelineIsActive = true;

    //Used when the timeline is frozen.
    bool timelineIsPaused = false;

    //How many times faster than normal time should we rewind/fast forward?
    float timelineRewindFactor = 10f;
    float timelineForwardFactor = 10f;

    //UIComponents
    [SerializeField]
    public Text clockDisplay;

    //References
    GameManger gameManager;
    
	// Use this for initialization
	void Start () {
        gameManager = GetComponent<GameManger>();
        if (gameManager == null) Debug.LogError("cannot finnd attached GameManager component in " + name);


	}
	
	// Update is called once per frame
	void Update () {

        //Checks the game state to set up what we should/should not be doing
        ReadState();

        if(timelineIsActive && !timelineIsPaused)
            AdvanceStep();

        CalculateClock();

    }

    void ReadState()
    {
        if (gameManager.timelineState == TimelineState.Active) timelineIsActive = true;
        else timelineIsActive = false;

        if (gameManager.timelineState == TimelineState.Paused) timelineIsPaused = true;
        else timelineIsPaused = false;
    }

    //Calculates the passage of in game time.
    void AdvanceStep()
    {
        currentTimePassed += Time.fixedDeltaTime;
        if(currentTimePassed >= timePerStep )
        {
            currentStep++;
            currentTimePassed = 0;
        }
    }

    //Determine what time we should be showing on the in game clock
    void CalculateClock()
    {
        int minutesPassedTotal = currentStep * gameMinutesPerStep;

        float tempHours = minutesPassedTotal / 60;
        
        currentHours = (int)Math.Floor(tempHours) + startingTime;
        currentMinutes = (minutesPassedTotal % 60);

        bool needsZero = currentMinutes < 10;

        string zeroFill;

        if (needsZero) zeroFill = "0";
        else zeroFill = "";

        clockDisplay.text = currentHours + " : " + zeroFill + currentMinutes;
    }
}
