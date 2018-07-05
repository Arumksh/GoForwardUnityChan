using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

    float speed = -0.2f;
    float deadLine = -10f;

    AudioSource m_hitSoundSource;

    // Use this for initialization
    void Start()
    {
        m_hitSoundSource = GetComponent<AudioSource>();
        // 生成された場所を出力する
        Debug.LogFormat("Position: {0}, {1}", transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(this.speed, 0, 0);

        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }
}
