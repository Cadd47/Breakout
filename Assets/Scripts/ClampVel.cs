using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampVel : MonoBehaviour
{
    private Rigidbody2D rb;
    public float maxVelocity = 10;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);
    }
}
