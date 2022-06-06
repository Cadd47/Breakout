using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMods : MonoBehaviour
{
    public GameObject currentMod;
    public GameObject[] mods;
    public int randMod;

    private void Update()
    {
        currentMod.SetActive(true);

        if (Input.GetKeyDown(KeyCode.P))
        {
            ChangePaddle();
        }
    }

    public void ChangePaddle()
    {
        randMod = Random.Range(0, mods.Length);

        foreach (GameObject mod in mods)
        {
            mod.SetActive(false);
        }

        currentMod = mods[randMod];
        currentMod.SetActive(true);
    }
}
