using GameManager;
using HarmonyQuest.Audio;
using System.Collections.Generic;
using UnityEngine;

public class RhythmTracker : ManageableObject
{
    public static RhythmTracker instance;

    float maxInterval;
    float curInterval;

    float maxRotation = 360f;

    public Transform record;
    Vector3 needleEulerAngles;

    public List<BeatNode> beatNodes;

    [HideInInspector]
    public int beat = 0;
    private int maxBeat = 8;

    public enum BeatCommandId { A = 0, B = 1, None = -1 };

    private List<BeatCommandId> commandQueue = null;

    string command;

    public override void OnAwake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    public override void OnStart()
    {
        FmodMusicHandler.instance.AssignFunctionToOnBeatDelegate(OnBeat);
        needleEulerAngles = record.transform.eulerAngles;
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

            needleEulerAngles.z = (curInterval / maxInterval) * maxRotation;
            record.eulerAngles = needleEulerAngles;
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
            //beatNodes.ForEach(a => a.OnBeat(beat));
            BeatCommandPool.instance.OnBeat(beat);
        }
        Enemy.instance.OnBeat(beat);
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

            BeatCommandPool.instance.StartBeatCommand(delay, 10, commandQueue[i], beatNodes[beatOffset].transform);
        }
    }

    void GenerateCommandQueueFromMenu()
    {
        commandQueue = NotePatterns.GetRandomPattern();
        ProcessCommand();
    }
}
