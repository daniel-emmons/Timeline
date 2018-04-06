using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewNPCBio", menuName = "NPC/Bio")]
public class NPCBio : ScriptableObject
{
    [Header("Attributes")]
    /// <summary>
    /// The name of the character, as it's displayed in game.
    /// </summary>
    [SerializeField()]
    public string DisplayName;

    /// <summary>
    /// The walking speed of this character.
    /// </summary>
    [SerializeField()]
    public float WalkSpeed;

    /// <summary>
    /// The goals that this NPC has planned for the entire game.
    /// </summary>
    [SerializeField()]
    public NPCSchedule Schedule;

    [Header("Curves")]

    /// <summary>
    /// The curve that represents this NPC's urgency to meet with other people.
    /// </summary>
    [SerializeField()]
    public AnimationCurve MeetingUtility;
}
