using GameManager;
using UnityEngine;
using UnityEngine.UI;

public class BeatNode : ManageableObject
{
    public Image neutral;
    private Color defaultColorNeutral;
    private Color fadedColorNeutral;

    public Image activeA, activeB;
    private Color defaultColorA, defaultColorB;
    private Color fadedColorA, fadedColorB;

    [HideInInspector]
    public bool isAWaitingToAct;
    [HideInInspector]
    public bool isBWaitingToAct;

    [HideInInspector]
    public bool isAActive;
    [HideInInspector]
    public bool isBActive;

    [HideInInspector]
    public bool isAVisible;
    [HideInInspector]
    public bool isBVisible;

    [HideInInspector]
    public int damage;

    private float activeTimerMax = 0.2f;
    private float activeTimer = 0f;

    private int beatDelay;

    // Start is called before the first frame update
    public override void OnStart()
    {
        defaultColorNeutral = neutral.color;
        fadedColorNeutral = defaultColorNeutral;
        fadedColorNeutral.a = 0.2f;
        neutral.color = fadedColorNeutral;

        defaultColorA = activeA.color;
        fadedColorA = defaultColorA;
        fadedColorA.a = 0.3f;
        activeA.color = fadedColorA;

        defaultColorB = activeB.color;
        fadedColorB = defaultColorB;
        fadedColorB.a = 0.3f;
        activeB.color = fadedColorB;

        activeA.enabled = false;
        activeB.enabled = false;
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
        if (isAWaitingToAct || isBWaitingToAct)
        {
            if (beatDelay <= 2)
            {
                Debug.Log("BEAT SHOW");
                ToggleAIsVisible(true);
                ToggleBIsVisible(true);
            }

            if (beatDelay == 0)
            {
                Debug.Log("BEAT");
                ToggleFaded(false);
                if (isAWaitingToAct)
                {
                    isAActive = true;
                }
                if (isBWaitingToAct)
                {
                    isBActive = true;
                }
            }
            else if (beatDelay < 0)
            {
                ToggleAIsVisible(false);
                ToggleBIsVisible(false);
                ToggleFaded(true);
                if (isAWaitingToAct)
                {
                    isAActive = false;
                }
                if (isBWaitingToAct)
                {
                    isBActive = false;
                }
            }
            beatDelay--;
        }
    }

    public void DelayedActivateA(int delay, int damage)
    {
        beatDelay = delay;
        isAWaitingToAct = true;
        this.damage = damage;
    }

    public void DelayedActivateB(int delay, int damage)
    {
        beatDelay = delay;
        isBWaitingToAct = true;
        this.damage = damage;
    }

    public void ToggleAIsVisible(bool visible)
    {
        if (isAWaitingToAct)
        {
            isAVisible = visible;
            activeA.enabled = visible;
        }
    }

    public void ToggleBIsVisible(bool visible)
    {
        if (isBWaitingToAct)
        {
            isBVisible = visible;
            activeB.enabled = visible;
        }
    }

    public void ToggleFaded(bool faded)
    {
        if (faded)
        {
            neutral.color = fadedColorNeutral;
            activeA.color = fadedColorA;
            activeB.color = fadedColorB;
        }
        else
        {
            neutral.color = defaultColorNeutral;
            activeA.color = defaultColorA;
            activeB.color = defaultColorB;
            activeTimer = activeTimerMax;
        }
    }
}
