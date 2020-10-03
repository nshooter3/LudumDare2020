using GameManager;
using HarmonyQuest.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : ManageableObject
{
    public override void OnStart()
    {

    }

    public override void OnUpdate()
    {
        CheckForInput();
    }

    public void CheckForInput()
    {
        if (RewiredPlayerInputManager.instance.GreenButtonDown())
        {
            if (BeatCommandPool.instance.IsInputValid(RhythmTracker.BeatCommandId.A))
            {
                Debug.Log("Green button hit!");
            }
            else
            {
                Debug.Log("Miss!");
            }
        }
        if (RewiredPlayerInputManager.instance.RedButtonDown())
        {
            if (BeatCommandPool.instance.IsInputValid(RhythmTracker.BeatCommandId.B))
            {
                Debug.Log("Red button hit!");
            }
            else
            {
                Debug.Log("Miss!");
            }
        }
        if (RewiredPlayerInputManager.instance.BlockButtonDown())
        {
            Debug.Log("Block button down!");
        }
    }
}
