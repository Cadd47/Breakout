using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Text : MonoBehaviour
{
    PaddleMods paddleMods;

    public TextMeshProUGUI balls;
    public static int ballCount = 3;

    public TextMeshProUGUI timer;
    float seconds = 9;
    float miliseconds = 0;

    private void Start()
    {
        paddleMods = GameObject.Find("GameManager").GetComponent<PaddleMods>();
    }

    private void Update()
    {
        balls.text = ballCount.ToString();

        if (miliseconds <= 0)
        {
            if (seconds <= 0)
            {
                paddleMods.ChangePaddle();
                seconds = 9;
            }
            else if (seconds >= 0)
            {
                seconds--;
            }

            miliseconds = 100;
        }
        miliseconds -= Time.deltaTime * 100;

        timer.text = string.Format("{0}", seconds);
    }
}
