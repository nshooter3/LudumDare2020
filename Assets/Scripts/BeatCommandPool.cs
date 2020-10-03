using GameManager;
using System.Collections.Generic;
using UnityEngine;

public class BeatCommandPool : ManageableObject
{
    private List<BeatCommand> beatCommands;

    public GameObject beatCommandPrefab;

    private GameObject tempBeatCommand;

    public int size = 20;

    public override void OnStart()
    {
        beatCommands = new List<BeatCommand>();
        for (int i = 0; i < size; i++)
        {
            tempBeatCommand = Instantiate(beatCommandPrefab);
            tempBeatCommand.transform.parent = transform;
            beatCommands.Add(tempBeatCommand.GetComponent< BeatCommand>());
        }
    }

    public void StartBeatCommand(int delay, int damage, RhythmTracker.BeatCommandId id, Vector3 position)
    {
        if (id != RhythmTracker.BeatCommandId.None)
        {
            GetAvailableBeatCommand().Activate(delay, damage, (int)id, position);
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
}
