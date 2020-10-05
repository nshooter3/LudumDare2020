using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Caution : MonoBehaviour
{
    public Image image;
    float waitTimer, waitTimerMax = 0.25f;

    void Start()
    {
        image.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (waitTimer > 0)
        {
            waitTimer -= Time.deltaTime;
            if (waitTimer <= 0)
            {
                image.enabled = false;
            }
        }
    }

    public void Activate()
    {
        image.enabled = true;
        waitTimer = waitTimerMax;
    }
}
