using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public HealthUI healthUI;
    private int health, maxHealth = 3000;
    public enum Phase { one, two, three, four };
    Phase phase = Phase.one;

    public static Enemy instance;

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
        else if (health <= maxHealth * .25f)
        {
            phase = Phase.four;
        }
        else if (health <= maxHealth * .5f)
        {
            phase = Phase.three;
        }
        else if (health <= maxHealth * .75f)
        {
            phase = Phase.two;
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
