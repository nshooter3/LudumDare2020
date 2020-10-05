using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fist : MonoBehaviour
{
    public Image image;
    private Color startColor, fadeColor;

    private Vector3 startPos, endPos;
    private float punchDistance = 200f;

    float fadeInTimer, fadeInTimerMax = 0.1f;
    float punchTimer, punchTimerMax = 0.1f;
    float waitTimer, waitTimerMax = 0.4f;
    float fadeOutTimer, fadeOutTimerMax = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        startColor = image.color;
        fadeColor = image.color;
        fadeColor.a = 0f;

        startPos = image.transform.position;
        endPos   = image.transform.position;
        endPos.x -= punchDistance;

        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeInTimer > 0)
        {
            fadeInTimer = Mathf.Max(0, fadeInTimer - Time.deltaTime);
            image.color = Color.Lerp(startColor, fadeColor, fadeInTimer / fadeInTimerMax);
        }

        if (punchTimer > 0)
        {
            punchTimer = Mathf.Max(0, punchTimer - Time.deltaTime);
            image.transform.position = Vector3.Lerp(endPos, startPos, punchTimer / punchTimerMax);
            if (punchTimer <= 0)
            {
                waitTimer = waitTimerMax;
            }
        }
        if (waitTimer > 0)
        {
            waitTimer = Mathf.Max(0, waitTimer - Time.deltaTime); ;
            if (waitTimer <= 0)
            {
                fadeOutTimer = fadeInTimerMax;
            }
        }
        if (fadeOutTimer > 0)
        {
            fadeOutTimer = Mathf.Max(0, fadeOutTimer - Time.deltaTime);
            image.color = Color.Lerp(fadeColor, startColor, fadeOutTimer / fadeOutTimerMax);
            if (fadeOutTimer <= 0)
            {
                Reset();
            }
        }
    }

    public void Activate()
    {
        Reset();
        fadeInTimer = fadeInTimerMax;
        punchTimer = punchTimerMax;
    }

    public void Reset()
    {
        image.color = fadeColor;
        image.transform.position = startPos;
        fadeInTimer = 0f;
        punchTimer = 0f;
        fadeOutTimer = 0f;
        waitTimer = 0f;
    }
}
