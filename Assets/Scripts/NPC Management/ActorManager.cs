using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorManager : Singleton<ActorManager>
{
    private List<Actor> m_actors = new List<Actor>();


	/// <summary>
    /// Start
    /// </summary>
	void Start () {
		
	}
	
	/// <summary>
    /// Update all of the actors.
    /// </summary>
	void Update ()
    {
        // Do not update actors when time is stopped.
        if(TimeManager.Instance.TimeScale != 0)
        {
            m_actors.ForEach(a => a.Update());
        }
	}

    /// <summary>
    /// Register an actor with the manager.
    /// </summary>
    public void RegisterNewActor(Actor actor)
    {
        if(!m_actors.Contains(actor))
        {
            m_actors.Add(actor);
        }
    }
}
