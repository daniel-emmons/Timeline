using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSchedule", menuName = "NPC/Schedule")]
public class NPCSchedule : ScriptableObject
{
    /// <summary>
    /// The list of all goals this NPC wants to do throughout the game.
    /// </summary>
    [SerializeField()]
    public List<NPCGoal> Schedule;
}
