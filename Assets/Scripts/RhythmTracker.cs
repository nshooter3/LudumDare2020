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

    [HideInInspector]
    public int beat = 0;
    private int maxBeat = 8;

    // Start is called before the first frame update
    public override void OnStart()
    {
        FmodMusicHandler.instance.AssignFunctionToOnBeatDelegate(OnBeat);
        needleEulerAngles = needle.transform.eulerAngles;
        RestartTimer();
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
        beatNodes.ForEach(a => a.OnBeat(beat));
        Debug.Log("BEAT: " + beat);
    }

    public void OnMeasure()
    {
        beat = 0;
        RestartTimer();
    }

    void RestartTimer()
    {
        maxInterval = FmodFacade.instance.GetBeatDuration() * maxBeat;
        curInterval = 0f;
    }
}
