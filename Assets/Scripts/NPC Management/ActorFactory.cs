using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ActorFactory
{
    private static string ActorObjectPath = "Actor";


    /// <summary>
    /// Designers can drop actors into a scene and they should work.
    /// This should generate an actor object and register it with the manager.
    /// </summary>
	public static Actor CreateActorWhenDroppedInScene()
    {
        Actor actor = new Actor();

        ActorManager.Instance.RegisterNewActor(actor);

        return actor;
    }

    /// <summary>
    /// The standard path of creating an actor, when the GameManager tells it to.
    /// </summary>
    public static void CreateActor(ActorBio bio)
    {
        Actor actor = new Actor()
        {
            Bio = bio
        };
        ActorManager.Instance.RegisterNewActor(actor);

        // Instantiate the actor game object.
        var actorResource = Resources.Load(ActorObjectPath);
        var actorGameObject = GameObject.Instantiate(actorResource, bio.StartingPosition, Quaternion.identity) as GameObject;
        actor.ActorObject = actorGameObject.GetComponent<ActorObject>();
        actor.ActorObject.Bio = bio;
    }
}
