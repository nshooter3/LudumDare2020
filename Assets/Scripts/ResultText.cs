using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultText : MonoBehaviour
{
    private float randomPositionRange = 30f;
    private Vector3 startPos, endPos;
    private float travelDistance = 50f, travelDistanceRange = 15;
    private float travelTimeMax = 0.5f, travelTime, stallTimeMax = 0.25f, stallTime;

    public Text text;

    private Color startColor, fadedColor;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        startPos.x += Random.Range(-randomPositionRange, randomPositionRange);
        startPos.y += Random.Range(-randomPositionRange, randomPositionRange);

        endPos = startPos;
        endPos.y += travelDistance + Random.Range(-travelDistanceRange, travelDistanceRange);

        travelTime = travelTimeMax;
        stallTime = stallTimeMax;

        startColor = text.color;
        fadedColor = text.color;
        fadedColor.a = 0f;
        transform.parent = MessageSpawner.instance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (travelTime > 0)
        {
            travelTime = Mathf.Max(0, travelTime - Time.deltaTime);
            transform.position = Vector3.Lerp(endPos, startPos, travelTime / travelTimeMax);
            text.color = Color.Lerp(startColor, fadedColor, travelTime / travelTimeMax);
        }
        else
        {
            if (stallTime > 0)
            {
                stallTime -= Time.deltaTime;
                if (stallTime <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
