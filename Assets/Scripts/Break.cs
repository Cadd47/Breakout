using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    Reset reset;
    private void Start()
    {
        reset = GameObject.Find("OutBounds").GetComponent<Reset>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            StartCoroutine(Die());
        }
    }
    IEnumerator Die()
    {
        yield return new WaitForSeconds(.1f);
        gameObject.SetActive(false);
        reset.point++;
    }
}
