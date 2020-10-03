using UnityEngine;
using GameManager;
using UnityEngine.UI;

public class BeatCommand : ManageableObject
{
    public int id = -1;

    public Image[] activeImages;
    private Color defaultColor;
    private Color fadedColor;

    [HideInInspector]
    public bool isActive;

    [HideInInspector]
    public bool isAcceptingInput;
    [HideInInspector]
    public bool isVisible;

    [HideInInspector]
    public int damage;

    private int beatDelay;

    private float activeTimerMax = 0.15f;
    private float activeTimer = 0f;

    // Start is called before the first frame update
    public override void OnStart()
    {
        defaultColor = activeImages[id].color;
        fadedColor = defaultColor;
        fadedColor.a = 0.3f;
        activeImages[id].color = fadedColor;

        activeImages[id].enabled = false;
    }

    // Update is called once per frame
    public override void OnUpdate()
    {
        if (activeTimer > 0)
        {
            activeTimer -= Time.deltaTime;
            if (activeTimer <= 0)
            {
                ToggleFaded(true);
            }
        }
    }

    public void OnBeat()
    {
        if (isActive)
        {
            if (beatDelay == 2)
            {
                ToggleIsVisible(true);
            }

            if (beatDelay == 0)
            {
                ToggleFaded(false);
                isAcceptingInput = true;
            }
            else if (beatDelay < 0)
            {
                Reset();
            }
            beatDelay--;
        }
    }

    public void Activate(int delay, int damage, int id, Vector3 position)
    {
        this.id = id;
        beatDelay = delay;
        isActive = true;
        this.damage = damage;
        transform.position = position;
    }

    public void ToggleIsVisible(bool visible)
    {
        if (isActive)
        {
            isVisible = visible;
            activeImages[id].enabled = visible;
        }
    }

    public void ToggleFaded(bool faded)
    {
        if (faded)
        {
            activeImages[id].color = fadedColor;
        }
        else
        {
            activeImages[id].color = defaultColor;
            activeTimer = activeTimerMax;
        }
    }

    public void Reset()
    {
        foreach (Image activeImage in activeImages)
        {
            activeImage.color = fadedColor;
            activeImage.enabled = false;
        }
        id = -1;
        activeTimer = 0f;
        isVisible = false;
        isActive = false;
        isAcceptingInput = false;
        damage = 0;
        beatDelay = 0;
    }
}
