using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static bool canLaunch;
    public GameObject ballSpawn;
    private Rigidbody2D rb;
    Vector3 lastVelocity;

    GameObject[] dupedBalls;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canLaunch = true;
    }

    void Update()
    {
        lastVelocity = rb.velocity;

        dupedBalls = GameObject.FindGameObjectsWithTag("Duped");
        foreach(GameObject dupedBall in dupedBalls)
        {
            Physics2D.IgnoreCollision(dupedBall.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        if (canLaunch)
        {
            gameObject.transform.position = ballSpawn.transform.position;

            if (Input.GetKey(KeyCode.Space))
            {
                Launch();
            }
        }
    }

    void Launch()
    {
        canLaunch = false;

        float rand = Random.Range(0, 2);
        if(rand < 1)
        {
            rb.AddForce(new Vector2(50, 300));
        }
        else
        {
            rb.AddForce(new Vector2(-50, 300));
        }
    }

    public void ResetBall()
    {
        canLaunch = true;
        rb.velocity = Vector2.zero;
        transform.position = ballSpawn.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        rb.velocity = direction * Mathf.Max(speed, 0f);
    }
}
