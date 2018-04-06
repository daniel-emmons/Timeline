using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewNPCBio", menuName = "NPC/Bio")]
public class ActorBio : ScriptableObject
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
    /// The starting world space position of this character.
    /// </summary>
    [SerializeField()]
    public Vector2 StartingPosition;

    /// <summary>
    /// The goals that this NPC has planned for the entire game.
    /// </summary>
    [SerializeField()]
    public ActorSchedule Schedule;

    [Header("Curves")]

    /// <summary>
    /// The curve that represents this NPC's urgency to meet with other people.
    /// </summary>
    [SerializeField()]
    public AnimationCurve MeetingUtility;
}
