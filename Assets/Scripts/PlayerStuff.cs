using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStuff : MonoBehaviour
{
    public HealthUI healthUI;
    private int health, maxHealth = 100;

    public static PlayerStuff instance;

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
        health = Mathf.Max(0, health - damage);
        healthUI.TakeDamage(health, maxHealth);
    }

    void Die()
    {

    }
}
