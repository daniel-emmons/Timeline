using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementGameTask : GameTask
{
    /// <summary>
    /// Where this NPC started.
    /// </summary>
    public Vector3 StartPosition;

    /// <summary>
    /// Where this NPC wants to go.
    /// </summary>
    public Vector3 GoalPosition;
}
