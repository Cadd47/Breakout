using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static bool canLaunch;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canLaunch = true;
    }

    void Update()
    {
        if (canLaunch)
        {


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
            rb.AddForce(new Vector2(5, 100));
        }
        else
        {
            rb.AddForce(new Vector2(-5, 100));
        }
    }
}
