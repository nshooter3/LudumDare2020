using GameManager;
using HarmonyQuest.Audio;
using System.Collections.Generic;
using UnityEngine;

public class RhythmTracker : ManageableObject
{
    float maxInterval;
    float curInterval;

    float maxRotation = 360f;

    public Transform needle;
    Vector3 needleEulerAngles;

    public List<BeatNode> beatNodes;
    public List<BeatNode> beatNodes2;

    [HideInInspector]
    public int beat = 0;
    private int maxBeat = 8;

    private List<string> commandQueue = null;
    private List<string> mainMenu = new List<string> { "a", "", "a", "", "b", "", "b", "" };

    string command;

    // Start is called before the first frame update
    public override void OnStart()
    {
        FmodMusicHandler.instance.AssignFunctionToOnBeatDelegate(OnBeat);
        needleEulerAngles = needle.transform.eulerAngles;
        OnMeasure();
    }

    // Update is called once per frame
    public override void OnUpdate()
    {
        //If fmod is being a dingus and hasn't loaded yet, stall until it's ready.
        if (maxInterval > 1000f)
        {
            RestartTimer();
        }
        else
        {
            curInterval = Mathf.Min(maxInterval, curInterval + Time.deltaTime);

            needleEulerAngles.z = maxRotation - (curInterval / maxInterval) * maxRotation;
            needle.eulerAngles = needleEulerAngles;
        }
    }

    public void OnBeat()
    {
        if (beat >= 8)
        {
            OnMeasure();
        }
        beat++;
        if (commandQueue != null)
        {
            beatNodes.ForEach(a => a.OnBeat());
            beatNodes2.ForEach(a => a.OnBeat());
        }
    }

    public void OnMeasure()
    {
        beat = 0;
        RestartTimer();
        GenerateCommandQueueFromMenu();
    }

    void RestartTimer()
    {
        maxInterval = FmodFacade.instance.GetBeatDuration() * maxBeat;
        curInterval = 0f;
    }

    void ProcessCommand()
    {
        for (int i = 0; i < commandQueue.Count; i++)
        {
            int beatOffset = i % 8;
            int measureOffset = 1 + (i / 8);
            int delay = maxBeat * measureOffset + beatOffset;

            if (commandQueue[i] == "a")
            {
                if (!beatNodes[beatOffset].isAWaitingToAct)
                {
                    beatNodes[beatOffset].DelayedActivateA(delay, 10);
                    Debug.Log("Beat A " + beatOffset + ", delay of " + delay);
                }
                else
                {
                    beatNodes2[beatOffset].DelayedActivateA(delay, 10);
                    Debug.Log("Beat 2 A " + beatOffset + ", delay of " + delay);
                }
            }
            if (commandQueue[i] == "b")
            {
                if (!beatNodes[beatOffset].isBWaitingToAct)
                {
                    beatNodes[beatOffset].DelayedActivateB(delay, 10);
                    Debug.Log("Beat B " + beatOffset + ", delay of " + delay);
                }
                else
                {
                    beatNodes2[beatOffset].DelayedActivateB(delay, 10);
                    Debug.Log("Beat 2 B " + beatOffset + ", delay of " + delay);
                }
            }
        }
    }

    void GenerateCommandQueueFromMenu()
    {
        commandQueue = new List<string>(mainMenu);
        ProcessCommand();
    }
}
