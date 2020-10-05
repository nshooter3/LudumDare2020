using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
    public Image image;
    private Color startColor, fadeColor;

    float fadeInTimer, fadeInTimerMax = 0.1f;
    float waitTimer, waitTimerMax = 0.5f;
    float fadeOutTimer, fadeOutTimerMax = 0.1f;

    Vector3 originalPos, downPos;
    float downPosY = -20f;

    public bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        startColor = image.color;
        fadeColor = image.color;
        fadeColor.a = 0f;
        image.color = fadeColor;

        originalPos = image.transform.position;
        downPos = image.transform.position;
        downPos.y -= downPosY;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeInTimer > 0)
        {
            fadeInTimer = Mathf.Max(0, fadeInTimer - Time.deltaTime);
            image.color = Color.Lerp(startColor, fadeColor, fadeInTimer / fadeInTimerMax);
            image.transform.position = Vector3.Lerp(downPos, originalPos, fadeInTimer / fadeInTimerMax);
            if (fadeInTimer <= 0)
            {
                waitTimer = waitTimerMax;
            }
        }
        if (waitTimer > 0)
        {
            waitTimer = Mathf.Max(0, waitTimer - Time.deltaTime);
            if (waitTimer <= 0)
            {
                fadeOutTimer = fadeOutTimerMax;
            }
        }
        if (fadeOutTimer > 0)
        {
            fadeOutTimer = Mathf.Max(0, fadeOutTimer - Time.deltaTime);
            image.color = Color.Lerp(fadeColor, startColor, fadeInTimer / fadeInTimerMax);
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
        active = true;
    }

    private void Reset()
    {
        active = false;
        image.color = fadeColor;
        image.transform.position = downPos;
        fadeInTimer = 0f;
        waitTimer = 0f;
        fadeOutTimer = 0f;
    }
}
