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

    public int activeBeat;

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
        
    }

    public void OnBeat(int beat)
    {
        int beatDif = activeBeat - beat;
        if ((beatDif < 3 && beatDif > 0) || beatDif < -6)
        {
            ToggleAIsVisible(true);
            ToggleBIsVisible(true);
        }
        else
        {
            ToggleAIsVisible(false);
            ToggleBIsVisible(false);
        }

        if (beat == activeBeat)
        {
            ToggleFaded(false);
        }
        else
        {
            ToggleFaded(true);
        }
    }

    public void ToggleIsAActive(bool active, int damage)
    {
        isAActive = active;
        ToggleFaded(isAActive);
        damage = 0;
    }

    public void ToggleIsBActive(bool active, int damage)
    {
        isBActive = active;
        ToggleFaded(isBActive);
        damage = 0;
    }

    public void ToggleAIsVisible(bool visible)
    {
        if (isAActive)
        {
            isAVisible = visible;
            activeA.enabled = visible;
        }
    }

    public void ToggleBIsVisible(bool visible)
    {
        if (isBActive)
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
        }
    }
}
