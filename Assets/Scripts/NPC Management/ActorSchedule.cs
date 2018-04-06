using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSchedule", menuName = "NPC/Schedule")]
public class ActorSchedule : ScriptableObject
{
    /// <summary>
    /// The list of all goals this NPC wants to do throughout the game.
    /// </summary>
    [SerializeField()]
    public List<ActorGoal> Schedule;
}
