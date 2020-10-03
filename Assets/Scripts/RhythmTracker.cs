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

    public BeatCommandPool beatCommandPool;

    [HideInInspector]
    public int beat = 0;
    private int maxBeat = 8;

    public enum BeatCommandId { A = 0, B = 1, None = -1 };

    private List<BeatCommandId> commandQueue = null;
    private List<BeatCommandId> mainMenu = new List<BeatCommandId> { BeatCommandId.A, BeatCommandId.None, BeatCommandId.B, BeatCommandId.None,
                                                                     BeatCommandId.A, BeatCommandId.None, BeatCommandId.B, BeatCommandId.None };

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
            beatNodes.ForEach(a => a.OnBeat(beat));
            beatCommandPool.OnBeat(beat);
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

            beatCommandPool.StartBeatCommand(delay, 10, commandQueue[i], beatNodes[beatOffset].transform.position);
        }
    }

    void GenerateCommandQueueFromMenu()
    {
        commandQueue = new List<BeatCommandId>(mainMenu);
        ProcessCommand();
    }
}
