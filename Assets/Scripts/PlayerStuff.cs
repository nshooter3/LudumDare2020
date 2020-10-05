using HarmonyQuest.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStuff : MonoBehaviour
{
    public HealthUI healthUI;
    public Shield guardShield;
    public Shield missShield;
    private int health, maxHealth = 100;

    public int baseDamage = 10;
    public int firstHalfDamageBuff = 3;

    public static PlayerStuff instance;

    public bool guarded = false;

    public bool dead = false;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        FmodFacade.instance.PlayPooledFmodEvent("PlayerHurt");
        health = Mathf.Max(0, health - damage);
        healthUI.TakeDamage(health, maxHealth);
    }

    public void Guard()
    {
        if (!ShieldActive())
        {
            guardShield.Activate();
            guarded = true;
        }
    }

    public void GuardMiss()
    {
        if (!ShieldActive())
        {
            missShield.Activate();
        }
    }

    public bool ShieldActive()
    {
        return missShield.active || guardShield.active;
    }

    void Die()
    {
        FmodFacade.instance.StopMusic();
        SceneManager.LoadScene("LoseScene");
    }
}
