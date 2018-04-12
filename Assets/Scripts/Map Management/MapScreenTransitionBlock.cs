using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MapScreenTransitionBlockOrientation
{
    Horizontal,
    Vertical
};

public class MapScreenTransitionBlock : MonoBehaviour
{

    public MapScreenTransitionBlockOrientation Orientation;

    public MapScreenTemplate LeftOrTopMapScreenTemplate;
    public MapScreenTemplate RightOrBottomMapScreenTemplate;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
