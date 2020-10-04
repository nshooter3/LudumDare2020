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
                //TODO: Damage enemy
                Debug.Log("Green button hit!");
            }
            else
            {
                BeatCommandPool.instance.Miss();
            }
        }
        if (RewiredPlayerInputManager.instance.RedButtonDown())
        {
            if (BeatCommandPool.instance.IsInputValid(RhythmTracker.BeatCommandId.B))
            {
                //TODO: Damage enemy
                Debug.Log("Red button hit!");
            }
            else
            {
                BeatCommandPool.instance.Miss();
            }
        }
        if (RewiredPlayerInputManager.instance.BlockButtonDown())
        {
            Debug.Log("Block button down!");
        }
    }
}
