using Rewired;
using GameManager;
using UnityEngine;

public class RewiredPlayerInputManager : ManageableObject
{
    public static RewiredPlayerInputManager instance;

    // The Rewired player id. Currently, this will always be 0.
    private int playerId = 0;

    // The Rewired Player
    private Player player;

    private bool debug = false;

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
        // Get the Rewired Player object for this player and keep it for the duration of the character's lifetime
        player = ReInput.players.GetPlayer(playerId);
    }

    public override void OnUpdate()
    {
        if (debug)
        {
            Debug.Log("Horizontal movement: " + GetHorizontalMovement());
            Debug.Log("Vertical movement: " + GetVerticalMovement());

            if (GreenButtonDown())
            {
                Debug.Log("Green button down!");
            }
            if (RedButtonDown())
            {
                Debug.Log("Red button down!");
            }
            if (BlockButtonDown())
            {
                Debug.Log("Block button down!");
            }
        }
    }

    public float GetHorizontalMovement()
    {
        return player.GetAxis("MoveHorizontal");
    }

    public float GetVerticalMovement()
    {
        return player.GetAxis("MoveVertical");
    }

    public bool GreenButtonDown()
    {
        return player.GetButtonDown("A");
    }

    public bool RedButtonDown()
    {
        return player.GetButtonDown("B");
    }

    public bool HealButtonDown()
    {
        return player.GetButtonDown("Heal");
    }

    public bool BlockButtonDown()
    {
        return player.GetButtonDown("Block");
    }
}
