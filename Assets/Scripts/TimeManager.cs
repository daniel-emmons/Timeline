using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class TimeManager : Singleton<TimeManager> {

    private const float StartingGameTime = 0f;
    private const float MaxTimeScale = 4;
    private const float MinTimeScale = -4f;
    private const float TimeScaleStepSize = 1f;

    public const float GameSecondsInARealSecond = 60;

    private float m_gameTimeInSeconds = StartingGameTime;
    private float m_currentTimeScale = 1f;

    public float TimeScale { get { return m_currentTimeScale; } }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Keep time moving, based on timescale.
        AdvanceTime();

        // Adjust the timescale with player input.
        AdjustTimeScale();
    }

    /// <summary>
    /// Get the current time in a more readable format.
    /// </summary>
    /// <returns></returns>
    public TimeSpan GetCurrentTime()
    {
        return TimeSpan.FromSeconds(m_gameTimeInSeconds);
    }

    /// <summary>
    /// Determine if the provided goal time has passed the current time.
    /// </summary>
    public bool IsPassedTime(TimeSpan goalTime)
    {
        return goalTime < GetCurrentTime();
    }

    /// <summary>
    /// Determine if the provided goal time is earlier than the current time.
    /// </summary>
    public bool IsBeforeTime(TimeSpan goalTime)
    {
        return goalTime > GetCurrentTime();
    }

    /// <summary>
    /// Convert game time into real time.
    /// </summary>
    public float GetRealSecondsFromGameSeconds(float gameSeconds)
    {
        return gameSeconds / GameSecondsInARealSecond;
    }

    /// <summary>
    /// Keep time moving. Factors in timescale.
    /// </summary>
    private void AdvanceTime()
    {
        // Move the time forward or backward.
        m_gameTimeInSeconds += Time.deltaTime * GameSecondsInARealSecond * m_currentTimeScale;

        // You cannot rewind past the start of time.
        if(m_gameTimeInSeconds < StartingGameTime)
        {
            m_gameTimeInSeconds = StartingGameTime;
        }
    }

    /// <summary>
    /// Adjust the timescale with player input.
    /// </summary>
    private void AdjustTimeScale()
    {
        if (Input.GetKeyDown(KeyCode.E) && m_currentTimeScale < MaxTimeScale)
        {
            m_currentTimeScale += TimeScaleStepSize;
        }

        if (Input.GetKeyDown(KeyCode.Q) && m_currentTimeScale > MinTimeScale)
        {
            m_currentTimeScale -= TimeScaleStepSize;
        }
    }
}
