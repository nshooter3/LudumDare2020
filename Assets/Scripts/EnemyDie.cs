using HarmonyQuest.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyDie : MonoBehaviour
{
    public Image image;
    private Color startColor, endColor;

    float timer, maxTimer = 1.5f;
    float wait, maxWait = 4f;

    // Start is called before the first frame update
    void Start()
    {
        startColor = Color.red;
        endColor = Color.red;
        endColor.a = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            image.color = Color.Lerp(endColor, startColor, timer/maxTimer);
            if (timer <= 0)
            {
                wait = maxWait;
            }
        }

        if (wait > 0)
        {
            wait -= Time.deltaTime;
            if (wait <= 0)
            {
                SceneManager.LoadScene("VictoryScene");
            }
        }
    }

    public void Activate()
    {
        FmodFacade.instance.PlayPooledFmodEvent("BossDeath");
        timer = maxTimer;
    }
}
