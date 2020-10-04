using UnityEngine;
using UnityEngine.UI;
using HarmonyQuest.Audio;

public class BeatCommand : MonoBehaviour
{
    public int id = -1;

    public Image[] activeImages;
    public Color[] defaultColors;
    public Color[] fadedColors;

    [HideInInspector]
    public bool isActive;

    [HideInInspector]
    public bool isAcceptingInput;
    [HideInInspector]
    public bool isVisible;

    [HideInInspector]
    public int damage;

    public int beatDelay;

    private float activeTimerMax = 0.15f;
    private float activeTimer = 0f;

    private float startInputTimerMax;
    private float startInputTimer;

    private float stopInputTimerMax;
    private float stopInputTimer;

    // Start is called before the first frame update
    public void OnStart()
    {
        startInputTimerMax = FmodMusicHandler.instance.GetBeatDuration() / 2f;
        stopInputTimerMax  = FmodMusicHandler.instance.GetBeatDuration() / 2f;

        defaultColors = new Color[activeImages.Length];
        fadedColors = new Color[activeImages.Length];
        for (int i = 0; i < activeImages.Length; i++)
        {
            defaultColors[i] = activeImages[i].color;
            fadedColors[i] = defaultColors[i];
            fadedColors[i].a = 0.3f;

            activeImages[i].color = fadedColors[i];

            activeImages[i].enabled = false;
        }
    }

    // Update is called once per frame
    public void OnUpdate()
    {
        if (activeTimer > 0)
        {
            activeTimer -= Time.deltaTime;
            if (activeTimer <= 0)
            {
                ToggleFaded(true);
            }
        }
        if (startInputTimer > 0)
        {
            startInputTimer -= Time.deltaTime;
            if (startInputTimer <= 0)
            {
                isAcceptingInput = true;
            }
        }
        if (stopInputTimer > 0)
        {
            stopInputTimer -= Time.deltaTime;
            if (stopInputTimer <= 0)
            {
                isAcceptingInput = false;
            }
        }
    }

    public void OnBeat()
    {
        //If fmod is being a dingus and hasn't loaded yet, stall until it's ready.
        if (startInputTimerMax > 1000f)
        {
            startInputTimerMax = FmodMusicHandler.instance.GetBeatDuration() / 2f;
        }
        if (stopInputTimerMax > 1000f)
        {
            stopInputTimerMax = FmodMusicHandler.instance.GetBeatDuration() / 2f;
        }

        if (isActive)
        {
            if (beatDelay == 2)
            {
                ToggleIsVisible(true);
            }

            if (beatDelay == 1)
            {
                startInputTimer = startInputTimerMax;
            }

            if (beatDelay == 0)
            {
                ToggleFaded(false);
                stopInputTimer = stopInputTimerMax;
            }
            else if (beatDelay < 0)
            {
                Reset();
            }
            beatDelay--;
        }
    }

    public void Activate(int delay, int damage, int id, Transform parent)
    {
        this.id = id;
        beatDelay = delay;
        isActive = true;
        this.damage = damage;
        transform.parent = parent;
        transform.localPosition = Vector3.zero;
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
            activeImages[id].color = fadedColors[id];
        }
        else
        {
            activeImages[id].color = defaultColors[id];
            activeTimer = activeTimerMax;
        }
    }

    public void Reset()
    {
        for (int i = 0; i < activeImages.Length; i++)
        {
            activeImages[i].color = fadedColors[i];
            activeImages[i].enabled = false;
        }
        id = -1;
        activeTimer = 0f;
        isVisible = false;
        isActive = false;
        isAcceptingInput = false;
        damage = 0;
        beatDelay = 0;
        startInputTimer = 0;
        stopInputTimer = 0;
    }
}
