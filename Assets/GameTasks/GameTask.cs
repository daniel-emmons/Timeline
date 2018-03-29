using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameTask {

    /// <summary>
    /// Where this NPC started.
    /// </summary>
    public Vector3 StartPosition;

    /// <summary>
    /// Where this NPC wants to go.
    /// </summary>
    public Vector3 GoalPosition;

    /// <summary>
    /// The time that this game task was started.
    /// </summary>
    public TimeSpan StartTime;

    /// <summary>
    /// When this NPC wants to reach their goal.
    /// </summary>
    public TimeSpan GoalTime;
}
