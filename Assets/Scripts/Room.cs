using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {

    Collider2D boundingBox;

    // Use this for initialization
    void Start () {
        boundingBox = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D (Collider2D col)
    {
        Debug.Log(col.gameObject.name);
    }

}
