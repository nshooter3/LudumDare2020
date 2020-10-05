using GameManager;
using HarmonyQuest.Audio;
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
                FmodFacade.instance.PlayPooledFmodEvent("HitA");
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
                FmodFacade.instance.PlayPooledFmodEvent("HitB");
            }
            else
            {
                FmodFacade.instance.PlayPooledFmodEvent("Miss");
                BeatCommandPool.instance.Miss();
            }
        }
        if (RewiredPlayerInputManager.instance.BlockButtonDown())
        {
            if (Enemy.instance.IsGuardValid())
            {
                FmodFacade.instance.PlayPooledFmodEvent("Guard");
                PlayerStuff.instance.Guard();
                Enemy.instance.ResetFist();
            }
            else
            {
                FmodFacade.instance.PlayPooledFmodEvent("Miss");
                PlayerStuff.instance.GuardMiss();
            }
        }
        if (RewiredPlayerInputManager.instance.HealButtonDown())
        {
            Debug.Log("Heal button down!");
        }
    }
}
