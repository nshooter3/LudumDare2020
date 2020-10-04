using UnityEngine;
using UnityEngine.UI;

public class Hit : MonoBehaviour
{
    public Image image;
    private Color startColor, fadedColor;
    private float fadeTimer, fadeTimerMax = 0.1f;

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
            image.color = Color.Lerp(fadedColor, startColor, fadeTimer / fadeTimerMax);
            if (fadeTimer <= 0)
            {
                Reset();
            }
        }
    }

    public void Activate(Vector3 position)
    {
        fadeTimer = fadeTimerMax;
        image.color = fadedColor;
        transform.position = position;
        isActive = true;
    }

    private void Reset()
    {
        fadeTimer = 0;
        image.color = fadedColor;
        isActive = false;
    }
}
