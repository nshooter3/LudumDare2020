using UnityEngine;
using UnityEngine.UI;
using HarmonyQuest.Audio;

public class BeatCommand : MonoBehaviour
{
    public int id = -1;

    public Image[] activeImages;
    public Text perfectImage;
    private Color[] defaultColors;
    private Color[] fadedColors;
    private Color[] fadedInColors;

    private Vector3[] defaultSizes;
    private Vector3[] biggerSizes;

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

    private float fadeInTimerMax;
    private float fadeInTimer;

    private float perfectRange;
    private bool perfect;

    // Start is called before the first frame update
    public void OnStart()
    {
        startInputTimerMax = FmodMusicHandler.instance.GetBeatDuration() / 2f;
        stopInputTimerMax  = FmodMusicHandler.instance.GetBeatDuration() / 2f;
        perfectRange       = FmodMusicHandler.instance.GetBeatDuration() / 4f;
        fadeInTimerMax     = FmodMusicHandler.instance.GetBeatDuration() * 5f;

        defaultColors = new Color[activeImages.Length];
        fadedColors = new Color[activeImages.Length];
        fadedInColors = new Color[activeImages.Length];
        defaultSizes = new Vector3[activeImages.Length];
        biggerSizes = new Vector3[activeImages.Length];

        for (int i = 0; i < activeImages.Length; i++)
        {
            defaultColors[i] = activeImages[i].color;
            fadedColors[i] = defaultColors[i];
            fadedColors[i].a = 0.0f;

            fadedInColors[i] = defaultColors[i];
            fadedInColors[i].a = 0.75f;

            activeImages[i].color = fadedColors[i];
            activeImages[i].enabled = false;

            defaultSizes[i] = activeImages[i].transform.localScale;
            biggerSizes[i] = activeImages[i].transform.localScale * 3.5f;
        }
    }

    // Update is called once per frame
    public void OnUpdate()
    {
        perfect = false;
        if (activeTimer > 0)
        {
            //perfectImage.enabled = false;
            activeTimer -= Time.deltaTime;
            if (activeTimer <= 0)
            {
                ToggleFaded(true);
            }
        }
        if (startInputTimer > 0)
        {
            startInputTimer -= Time.deltaTime;
            if (startInputTimer <= startInputTimerMax / 1.6f)
            {
                perfect = true;
                //perfectImage.enabled = true;
            }
            if (startInputTimer <= 0)
            {
                isAcceptingInput = true;
            }
        }
        if (stopInputTimer > 0)
        {
            stopInputTimer -= Time.deltaTime;
            if (stopInputTimer >= stopInputTimerMax / 2.4f)
            {
                perfect = true;
                //perfectImage.enabled = true;
            }
            if (stopInputTimer <= 0)
            {
                FmodFacade.instance.PlayPooledFmodEvent("Miss");
                MessageSpawner.instance.SpawnMissResult();
                MissPool.instance.StartMiss(transform.position, Vector3.Scale(transform.parent.transform.localScale, GetScale()));
                Reset();
            }
        }
        if (fadeInTimer > 0)
        {
            fadeInTimer = Mathf.Max(0, fadeInTimer - Time.deltaTime);
            activeImages[id].color = Color.Lerp(fadedInColors[id], fadedColors[id], fadeInTimer/fadeInTimerMax);
            activeImages[id].transform.localScale = Vector3.Lerp(defaultSizes[id], biggerSizes[id], fadeInTimer / fadeInTimerMax);
        }
    }

    public bool IsPerfect()
    {
        return perfect;
    }

    public void OnBeat()
    {
        //If fmod is being a dingus and hasn't loaded yet, stall until it's ready.
        if (startInputTimerMax > 1000f)
        {
            startInputTimerMax = FmodMusicHandler.instance.GetBeatDuration() / 2f;
            stopInputTimerMax  = FmodMusicHandler.instance.GetBeatDuration() / 2f;
            perfectRange       = FmodMusicHandler.instance.GetBeatDuration() / 4f;
            fadeInTimerMax     = FmodMusicHandler.instance.GetBeatDuration() * 5f;
        }

        if (isActive)
        {
            if (beatDelay == 6)
            {
                ToggleIsVisible(true);
                fadeInTimer = fadeInTimerMax;
            }

            if (beatDelay == 1)
            {
                startInputTimer = startInputTimerMax;
            }

            if (beatDelay == 0)
            {
                fadeInTimer = 0;
                ToggleFaded(false);
                stopInputTimer = stopInputTimerMax;
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
            activeImages[i].transform.localScale = defaultSizes[i];
        }
        id = -1;
        activeTimer = 0f;
        isVisible = false;
        isActive = false;
        isAcceptingInput = false;
        damage = 0;
        beatDelay = 0;
        startInputTimer = 0f;
        stopInputTimer = 0f;
        fadeInTimer = 0f;
        perfect = false;
        //perfectImage.enabled = false;
    }

    public Vector3 GetScale()
    {
        if (id >= 0)
        {
            return activeImages[id].transform.localScale;
        }
        return Vector3.one;
    }
}
