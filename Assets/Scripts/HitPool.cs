using GameManager;
using System.Collections.Generic;
using UnityEngine;

public class HitPool : ManageableObject
{
    public static HitPool instance;

    private List<Hit> hits;

    public Hit hitPrefab;
    public int size;

    private Hit tempHit;

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
        hits = new List<Hit>();
        for (int i = 0; i < size; i++)
        {
            tempHit = Instantiate(hitPrefab, transform, false);
            hits.Add(tempHit);
            hits[i].OnStart();
        }
    }

    // Update is called once per frame
    public override void OnUpdate()
    {
        hits.ForEach(a => a.OnUpdate());
    }

    public void StartHit(Vector3 position)
    {
        tempHit = GetAvailableHit();
        if (tempHit != null)
        {
            tempHit.Activate(position);
        }
    }

    public Hit GetAvailableHit()
    {
        foreach (Hit hit in hits)
        {
            if (hit.isActive == false)
            {
                return hit;
            }
        }
        return null;
    }
}
