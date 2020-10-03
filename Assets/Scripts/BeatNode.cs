using GameManager;
using UnityEngine;
using UnityEngine.UI;

public class BeatNode : ManageableObject
{
    public Image neutral;
    private Color defaultColorNeutral;
    private Color fadedColorNeutral;

    public int activeBeat;

    private float activeTimerMax = 0.15f;
    private float activeTimer = 0f;

    // Start is called before the first frame update
    public override void OnStart()
    {
        if (neutral != null)
        {
            defaultColorNeutral = neutral.color;
            fadedColorNeutral = defaultColorNeutral;
            fadedColorNeutral.a = 0.2f;
            neutral.color = fadedColorNeutral;
        }
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

    public void OnBeat(int beat)
    {
        if (beat == activeBeat)
        {
            ToggleFaded(false);
        }
        else
        {
            ToggleFaded(true);
        }
    }

    public void ToggleFaded(bool faded)
    {
        if (faded)
        {
            neutral.color = fadedColorNeutral;
        }
        else
        {
            neutral.color = defaultColorNeutral;
        }
    }
}
