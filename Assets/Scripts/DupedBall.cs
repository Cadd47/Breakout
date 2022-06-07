using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DupedBall : MonoBehaviour
{
    private Rigidbody2D rb;
    GameObject ball;
    GameObject[] dupedBalls;
    Vector3 lastVelocity;

    void Awake()
    {
        ball = GameObject.Find("Ball");
        rb = GetComponent<Rigidbody2D>();

        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            rb.AddForce(new Vector2(100, 250));
        }
        else
        {
            rb.AddForce(new Vector2(-100, 250));
        }
    }

    void Update()
    {
        lastVelocity = rb.velocity;

        Physics2D.IgnoreCollision(ball.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        dupedBalls = GameObject.FindGameObjectsWithTag("Duped");
        foreach (GameObject dupedBall in dupedBalls)
        {
            Physics2D.IgnoreCollision(dupedBall.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        rb.velocity = direction * Mathf.Max(speed, 0f);
    }
}
