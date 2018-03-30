using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public abstract class GameTask : ScriptableObject
{
    [SerializeField()]
    private SerializableTimeSpan m_startTime;

    [SerializeField()]
    private SerializableTimeSpan m_goalTime;



    /// <summary>
    /// The time that this game task was started.
    /// </summary>
    public TimeSpan StartTime
    {
        get { return m_startTime.GetTimespan(); }
        set { m_startTime = new SerializableTimeSpan(value); }
    }

    /// <summary>
    /// When this NPC wants to reach their goal.
    /// </summary>
    public TimeSpan GoalTime
    {
        get { return m_goalTime.GetTimespan(); }
        set { m_goalTime = new SerializableTimeSpan(value); }
    }
}
