using HarmonyQuest.Audio;
using UnityEngine;

public class BobToBeat : MonoBehaviour
{
    private Vector3 startPos, bobPos;
    private Vector3 startScale, bigScale;
    private float bobDistance = 7f;

    private float bobTimer, maxBobTimer = 0.25f;

    private bool bobThisBeat = true;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        bobPos = transform.position;
        bobPos.y += bobDistance;

        startScale = transform.localScale;
        bigScale = transform.localScale * 1.025f;

        FmodMusicHandler.instance.AssignFunctionToOnBeatDelegate(OnBeat);
    }

    // Update is called once per frame
    void Update()
    {
        if (bobTimer > 0f)
        {
            bobTimer = Mathf.Max(0f, bobTimer - Time.deltaTime);
            transform.position = Vector3.Lerp(startPos, bobPos, bobTimer / maxBobTimer);
            transform.localScale = Vector3.Lerp(startScale, bigScale, bobTimer / maxBobTimer);
        }
    }

    public void OnBeat()
    {
        if (bobThisBeat)
        {
            bobTimer = maxBobTimer;
        }
        bobThisBeat = !bobThisBeat;
    }
}
