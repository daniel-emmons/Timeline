using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorObject : MonoBehaviour {

    /// <summary>
    /// A reference to the Bio from the Actor class.
    /// </summary>
    public ActorBio Bio;

    /// <summary>
    /// Reference to the actor class this corresponds with.
    /// </summary>
    private Actor m_actor;

	/// <summary>
    /// Game Object initialization.
    /// </summary>
	void Start ()
    {
        // If necessary, spawn this actor object as an actor.
        InitializeWhenDroppedIntoScene();
    }

    /// <summary>
    /// Initialize this actor object when spawned in code.
    /// </summary>
    public void Initialize(Actor actor)
    {
        m_actor = actor;
    }
	
    /// <summary>
    /// Initialize this actor object when dropped into a scene by a designer.
    /// This allows actors to be tested with schedules without going through a bunch of weird steps.
    /// </summary>
    private void InitializeWhenDroppedIntoScene()
    {
        if(m_actor == null)
        {
            m_actor = ActorFactory.CreateActorWhenDroppedInScene();
            m_actor.ActorObject = this;
            m_actor.Bio = Bio;
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
