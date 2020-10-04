using UnityEngine;
using UnityEngine.UI;

public class Miss : MonoBehaviour
{
    public Image image;
    private Color startColor, fadedColor;
    private float fadeTimer, fadeTimerMax = 0.5f;

    private Vector3 StartPos, EndPos;

    [HideInInspector]
    public bool isActive;

    // Start is called before the first frame update
    public void OnStart()
    {
        startColor = image.color;
        fadedColor = startColor;
        fadedColor.a = 0f;
        image.color = fadedColor;
    }

    // Update is called once per frame
    public void OnUpdate()
    {
        if (fadeTimer > 0f)
        {
            fadeTimer = Mathf.Max(0f, fadeTimer -= Time.deltaTime);
            image.color = Color.Lerp(fadedColor, startColor, fadeTimer/fadeTimerMax);
            image.transform.position = Vector3.Lerp(EndPos, StartPos, fadeTimer / fadeTimerMax);
            if (fadeTimer <= 0)
            {
                Reset();
            }
        }
    }

    public void Activate(Vector3 position, Vector3 scale)
    {
        fadeTimer = fadeTimerMax;
        image.color = fadedColor;
        transform.position = position;
        transform.localScale = scale;
        StartPos = position;
        EndPos = position;
        EndPos.y += 30f;
        isActive = true;
    }

    private void Reset()
    {
        fadeTimer = 0;
        image.color = fadedColor;
        isActive = false;
    }
}
