using UnityEngine;

public class MessageSpawner : MonoBehaviour
{
    public ResultText perfectResult, goodResult, missResult;

    public static MessageSpawner instance;

    private void Awake()
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

    public void SpawnPerfectResult()
    {
        Instantiate(perfectResult);
    }

    public void SpawnGoodResult()
    {
        Instantiate(goodResult);
    }

    public void SpawnMissResult()
    {
        Instantiate(missResult);
    }
}
