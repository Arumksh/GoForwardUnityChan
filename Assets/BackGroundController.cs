using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour {

    float scrollSpeed = -0.03f;
    float deadLine = -16;
    float startLine = 15.8f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(this.scrollSpeed, 0, 0);

        if(transform.position.x < this.deadLine)
        {
            transform.position = new Vector2(startLine, 0);
        }
	}
}
