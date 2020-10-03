using GameManager;
using HarmonyQuest.Audio;
using UnityEngine;

public class RhythmTracker : ManageableObject
{
    float maxInterval;
    float curInterval;

    float maxRotation = 360f;

    public Transform needle;
    Vector3 needleEulerAngles;

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
        if (maxInterval > 100f)
        {
            RestartTimer();
        }
        else
        {
            curInterval = Mathf.Max(0, curInterval - Time.deltaTime);

            needleEulerAngles.z = (curInterval / maxInterval) * maxRotation;
            Debug.Log("needleEulerAngles " + needleEulerAngles);
            needle.eulerAngles = needleEulerAngles;
        }
    }

    public void OnBeat()
    {
        RestartTimer();
    }

    void RestartTimer()
    {
        maxInterval = FmodFacade.instance.GetBeatDuration();
        curInterval = maxInterval;
    }
}
