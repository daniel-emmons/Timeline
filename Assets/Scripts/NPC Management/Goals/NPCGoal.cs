using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public abstract class NPCGoal : ScriptableObject
{
    [SerializeField()]
    private SerializableTimeSpan m_goalTime;


    /// <summary>
    /// When this NPC wants to reach their goal.
    /// </summary>
    public TimeSpan GoalTime
    {
        get { return m_goalTime.GetTimespan(); }
        set { m_goalTime = new SerializableTimeSpan(value); }
    }

    /// <summary>
    /// Every goal needs a way of estimating how long it will take to complete.
    /// </summary>
    public abstract float GetTimeToCompleteInSeconds();
}
