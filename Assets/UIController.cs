using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    GameObject gameOverText;
    GameObject runLengthtext;

    float len = 0f;
    float speed = 2.0f;

    bool isGameOver = false;

    // Use this for initialization
    void Start()
    {
        this.gameOverText = GameObject.Find("GameOver");
        this.runLengthtext = GameObject.Find("RunLength");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isGameOver == false)
        {
            this.len += this.speed * Time.deltaTime;
            this.runLengthtext.GetComponent<Text>().text = "Distance:" + len.ToString("F2") + "m";
        }

        if (this.isGameOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("GameScene");
            }
        }
    }

    public void GameOver()
    {
        this.gameOverText.GetComponent<Text>().text = "GameOver";
        this.isGameOver = true;
    }
}
