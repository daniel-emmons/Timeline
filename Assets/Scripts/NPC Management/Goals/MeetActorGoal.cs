using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPC Goal", menuName = "NPC/Goal/Meet NPC")]
public class MeetActorGoal : ActorGoal
{
    /// <summary>
    /// The position where this NPC will go to meet another NPC.
    /// </summary>
    [SerializeField()]
    public Vector2 GoalPosition;

    /// <summary>
    /// Based on the character's walking speed and the distance needed to travel, calculate how long it should take.
    /// </summary>
    public override TimeSpan GetTimeToComplete(Actor actor)
    {
        // Get the distance to the goal.
        float distance = Vector2.Distance(actor.CurrentPosition, GoalPosition);

        // Get the actor's walk speed.
        float walkSpeed = actor.Bio.WalkSpeed;

        // Divide the distance by speed to get time.
        float timeSeconds = distance / walkSpeed;
        return TimeSpan.FromSeconds(timeSeconds);
    }
}
