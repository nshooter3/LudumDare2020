using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTakeDamage : MonoBehaviour
{
    public Image image;
    private Color startColor, endColor;

    float timer, maxTimer = 0.15f;

    // Start is called before the first frame update
    void Start()
    {
        startColor = Color.Lerp(image.color, Color.red, 0.25f);
        endColor = image.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            image.color = Color.Lerp(endColor, startColor, timer / maxTimer);
        }
    }

    public void Activate()
    {
        timer = maxTimer;
    }

    public void Reset()
    {
        timer = 0;
    }
}
