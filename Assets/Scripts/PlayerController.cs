using GameManager;
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
            if (Enemy.instance.IsGuardValid())
            {
                PlayerStuff.instance.Guard();
            }
            else
            {
                PlayerStuff.instance.GuardMiss();
            }
        }
        if (RewiredPlayerInputManager.instance.HealButtonDown())
        {
            Debug.Log("Heal button down!");
        }
    }
}
