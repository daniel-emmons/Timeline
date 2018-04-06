using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorManager : Singleton<ActorManager>
{
    private List<Actor> m_actors = new List<Actor>();


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RegisterNewActor(Actor actor)
    {

    }
}
