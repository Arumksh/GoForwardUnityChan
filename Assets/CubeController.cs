using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

    public AudioClip audioClip;
    AudioSource audioSource;

    float speed = -0.2f;
    float deadLine = -10f;

    // Use this for initialization
    void Start()
    {
        this.audioSource = GetComponent<AudioSource>();
        // 生成された場所を出力する
        Debug.LogFormat("Position: {0}, {1}", transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void FixedUpdate () {
        transform.Translate(this.speed, 0, 0);

        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if(other.gameObject.tag != "Player")
        {
            audioSource.PlayOneShot(audioClip, Random.Range(0.5f, 1.0f));
        }
    }
}
