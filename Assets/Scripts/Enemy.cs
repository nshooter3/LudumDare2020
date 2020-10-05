using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public HealthUI healthUI;
    private int health, maxHealth = 2500;
    public enum Phase { one, two, three, four };
    Phase phase = Phase.one;
    bool isAttacking = false;
    private int attackSequence = -1, maxAttackSequence = 5;

    public Caution caution;
    public Fist fist;

    public static Enemy instance;

    private int attackOdds1 = 6;
    private int attackOdds2 = 3;
    private int attackOdds;

    private int damage = 5;

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

    public void OnBeat(int beat)
    {
        CheckForAttack(beat);

        if (attackSequence >= 0)
        {
            if (attackSequence == 5 || attackSequence == 3)
            {
                caution.Activate();
            }
            else if (attackSequence == 1)
            {
                fist.Activate();
            }
            else if (attackSequence == 0)
            {
                isAttacking = false;
                if (!PlayerStuff.instance.guarded)
                {
                    PlayerStuff.instance.TakeDamage(damage * 2);
                }
                else
                {
                    PlayerStuff.instance.TakeDamage(damage);
                }
                PlayerStuff.instance.guarded = false;
            }
            attackSequence--;
        }
    }

    public bool IsGuardValid()
    {
        return attackSequence <= 2 && attackSequence >= 0;
    }

    private void CheckForAttack(int beat)
    {
        if (phase != Phase.one)
        {
            attackOdds = attackOdds1;
            if (phase == Phase.four)
            {
                attackOdds = attackOdds2;
            }

            if (Random.Range(0, attackOdds) == 0)
            {
                if (!isAttacking && beat == 5 || beat == 1)
                {
                    isAttacking = true;
                    attackSequence = maxAttackSequence;
                    PlayerStuff.instance.guarded = false;
                }
            }
        }
    }

    public bool IsHalfwayDone()
    {
        return phase == Phase.three || phase == Phase.four;
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
