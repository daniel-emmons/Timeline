using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float moveSpeed = 3f;

    public float interactionBoxDistace = 1f;

    BoxCollider2D interactionBox;

    FacingDirection facingDirection = FacingDirection.Down;

	// Use this for initialization
	void Start () {
        interactionBox = GetComponentInChildren<BoxCollider2D>();
        
    }
	
	// Update is called once per frame
	void Update () {
        BasicMovement();
        Facing();
    }


    //Moves the character around
    void BasicMovement ()
    {
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.Translate(0, moveSpeed, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.Translate(0, -moveSpeed, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Translate(-moveSpeed,0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Translate(moveSpeed, 0, 0);
        }
    }

    //Determines which direction the character should be facing
    void Facing()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            facingDirection = FacingDirection.Up;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            facingDirection = FacingDirection.Down;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            facingDirection = FacingDirection.Left;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            facingDirection = FacingDirection.Right;
        }

        switch(facingDirection)
        {
            case (FacingDirection.Up):
                interactionBox.gameObject.transform.eulerAngles = new Vector3(0f, 0f, 90f);
                interactionBox.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + interactionBoxDistace);
                break;
            case (FacingDirection.Down):
                interactionBox.gameObject.transform.eulerAngles = new Vector3(0f, 0f, 90f); 
                interactionBox.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y - interactionBoxDistace);
                break;
            case (FacingDirection.Left):
                interactionBox.gameObject.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                interactionBox.gameObject.transform.position = new Vector3(transform.position.x- interactionBoxDistace, transform.position.y);
                break;
            case (FacingDirection.Right):
                interactionBox.gameObject.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                interactionBox.gameObject.transform.position = new Vector3(transform.position.x + interactionBoxDistace, transform.position.y);
                break;
        }

    }
}

public enum FacingDirection
{
    Up,
    Down,
    Left,
    Right

}
