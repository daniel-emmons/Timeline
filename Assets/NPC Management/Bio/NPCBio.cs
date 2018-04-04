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
}
