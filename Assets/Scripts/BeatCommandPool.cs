﻿using GameManager;
using HarmonyQuest.Audio;
using System.Collections.Generic;
using UnityEngine;

public class BeatCommandPool : ManageableObject
{
    public static BeatCommandPool instance;

    private List<BeatCommand> beatCommands;

    public GameObject beatCommandPrefab;

    private GameObject tempBeatCommand;

    public int size = 20;

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

    public override void OnStart()
    {
        beatCommands = new List<BeatCommand>();
        for (int i = 0; i < size; i++)
        {
            tempBeatCommand = Instantiate(beatCommandPrefab, transform, false);
            beatCommands.Add(tempBeatCommand.GetComponent< BeatCommand>());
            beatCommands[i].OnStart();
        }
    }

    public override void OnUpdate()
    {
        beatCommands.ForEach(a => a.OnUpdate());
    }

    public void StartBeatCommand(int delay, int damage, RhythmTracker.BeatCommandId id, Transform parent)
    {
        if (id != RhythmTracker.BeatCommandId.None)
        {
            GetAvailableBeatCommand().Activate(delay, damage, (int)id, parent);
        }
    }

    public void OnBeat(int beat)
    {
        beatCommands.ForEach(a => a.OnBeat());
    }

    public BeatCommand GetAvailableBeatCommand()
    {
        foreach (BeatCommand beatCommand in beatCommands)
        {
            if (beatCommand.isActive == false)
            {
                return beatCommand;
            }
        }
        return null;
    }

    public bool IsInputValid(RhythmTracker.BeatCommandId id)
    {
        foreach (BeatCommand beatCommand in beatCommands)
        {
            if (beatCommand.isAcceptingInput && (RhythmTracker.BeatCommandId) beatCommand.id == id)
            {
                int damage;
                HitPool.instance.StartHit(beatCommand.transform.position);
                if (beatCommand.IsPerfect())
                {
                    MessageSpawner.instance.SpawnPerfectResult();
                    damage = beatCommand.damage * 2;
                    Enemy.instance.TakeDamage(beatCommand.damage * 2);
                }
                else
                {
                    MessageSpawner.instance.SpawnGoodResult();
                    damage = beatCommand.damage;
                }
                //Do a little extra damage in the first half of the fight to compensate for less notes.
                if (!Enemy.instance.IsHalfwayDone())
                {
                    damage += PlayerStuff.instance.firstHalfDamageBuff;
                }
                Enemy.instance.TakeDamage(damage);
                beatCommand.Reset();
                return true;
            }
        }
        return false;
    }

    public void Miss()
    {
        BeatCommand closestNote = null;
        foreach (BeatCommand beatCommand in beatCommands)
        {
            if (beatCommand.isVisible && beatCommand.beatDelay >= 0 && beatCommand.beatDelay < 1)
            {
                if (closestNote == null || beatCommand.beatDelay < closestNote.beatDelay)
                {
                    closestNote = beatCommand;
                }
            }
        }

        if (closestNote != null)
        {
            FmodFacade.instance.PlayPooledFmodEvent("Miss");
            MessageSpawner.instance.SpawnMissResult();
            MissPool.instance.StartMiss(closestNote.transform.position, Vector3.Scale(closestNote.transform.parent.transform.localScale, closestNote.GetScale()));
            closestNote.Reset();
        }
    }
}
