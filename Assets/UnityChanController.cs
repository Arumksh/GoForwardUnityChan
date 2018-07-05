using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour {

    Animator animator;
    Rigidbody2D rigid2D;
    AudioSource audioSource;

    float groundLevel = -3.0f;
    float dump = 0.8f;
    float jumpVelocity = 20;
    float deadLine = -9f;

    bool jump = false;

    // Use this for initialization
    void Start () {
        this.animator = GetComponent<Animator>();
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        this.animator.SetFloat("Horizontal", 1);

        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        this.animator.SetBool("isGround", isGround);

        audioSource.volume = (isGround) ? 1 : 0;

        if (Input.GetMouseButtonDown(0) && isGround)
        {
            jump = true;
        }

        if(Input.GetMouseButton(0) == false)
        {
            if (this.rigid2D.velocity.y > 0)
            {
                this.rigid2D.velocity *= this.dump;
            }
        }

        if (transform.position.x < this.deadLine)
        {
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();
            Destroy(gameObject);
        }

        if(transform.position.x > -2.9f)
        {
            Vector2 pos = this.gameObject.transform.position;
            this.gameObject.transform.position = new Vector2(-2.9f, pos.y);
        }
    }

    void FixedUpdate() 
    {
        if (jump == true)
        {
            this.rigid2D.velocity = new Vector2(0, this.jumpVelocity);
            jump = false;
        }
    }
}
