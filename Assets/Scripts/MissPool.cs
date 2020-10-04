using GameManager;
using System.Collections.Generic;
using UnityEngine;

public class MissPool : ManageableObject
{
    public static MissPool instance;

    private List<Miss> misses;

    public Miss missPrefab;
    public int size;

    private Miss tempMiss;

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
        misses = new List<Miss>();
        for (int i = 0; i < size; i++)
        {
            tempMiss = Instantiate(missPrefab);
            tempMiss.transform.parent = transform;
            misses.Add(tempMiss);
            misses[i].OnStart();
        }
    }

    // Update is called once per frame
    public override void OnUpdate()
    {
        misses.ForEach(a => a.OnUpdate());
    }

    public void StartMiss(Vector3 position, Vector3 scale)
    {
        tempMiss = GetAvailableMiss();
        if (tempMiss != null)
        {
            tempMiss.Activate(position, scale);
        }
    }

    public Miss GetAvailableMiss()
    {
        foreach (Miss miss in misses)
        {
            if (miss.isActive == false)
            {
                return miss;
            }
        }
        return null;
    }
}