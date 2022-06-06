using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    Ball ball;
    public GameObject loser;
    public GameObject winner;
    public GameObject bricks;

    public int point = 0;

    private void Start()
    {
        ball = GameObject.Find("Ball").GetComponent<Ball>();
    }

    private void Update()
    {
        if(point == 60)
        {
            Win();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(Text.ballCount > 1)
            {
                Text.ballCount--;
                ball.ResetBall();
            }
            else
            {
                Text.ballCount--;
                loser.SetActive(true);
            }
        }
    }

    public void Restart()
    {
        ball.ResetBall();
        Text.ballCount = 3;
        point = 0;

        for (int i = 0; i < bricks.transform.childCount; i++)
        {
            bricks.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void Win()
    {
        winner.SetActive(true);
    }
}
