using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBattle : MonoBehaviour
{
    [SerializeField] Party partyClass;
    [SerializeField] Titan enemy;
    List<Titan> activeParty;
    [SerializeField] GameObject battleButton;

    // Start is called before the first frame update
    void Start()
    {
        activeParty = partyClass.activeParty;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            Turn();
        }
    }

    public void Turn()
    {
        // Beginning Phase
        // Activates enemy's beginning of turn ability (if applicable)
        enemy.OnBeginTurn(activeParty, enemy);
        // Activates party's beginning of turn abilities (if applicable)
        for (int i = 0; i < activeParty.Count; i++)
        {
            if (activeParty[i] != null)
            {
                activeParty[i].OnBeginTurn(activeParty, enemy);
            }
        }

        // Attack Phase
        // Enemy attacks party
        enemy.Attack(activeParty);
        // Front two members attack enemy
        activeParty[0].Attack(enemy, activeParty[0].damage);
        activeParty[3].Attack(enemy, activeParty[3].damage);

        // Death Phase
        // Checks if the enemy is dead and ends the battle if so
        if (enemy.DeathCheck(activeParty, enemy))
        {
            EndBattle();
        }

        // Checks if any party members in the top row have died
        for (int i = 0; i < 3; i++)
        {
            if (activeParty[i] != null && activeParty[i].DeathCheck(activeParty, enemy))
            {
                if (i == 0)
                {
                    activeParty[0] = activeParty[1];
                    activeParty[0].titanPosition = 0;

                    activeParty[1] = activeParty[2];
                    activeParty[1].titanPosition = 1;

                    activeParty[2] = null;
                }
                else if (i == 1)
                {
                    activeParty[1] = activeParty[2];
                    activeParty[1].titanPosition = 1;

                    activeParty[2] = null;
                }
                else
                {
                    activeParty[2] = null;
                }
            }
        }

        // Checks if any party members in the bottom row have died
        for (int i = 3; i < 6; i++)
        {
            if (activeParty[i] != null && activeParty[i].DeathCheck(activeParty, enemy))
            {
                if (i == 3)
                {
                    activeParty[3] = activeParty[4];
                    activeParty[3].titanPosition = 3;

                    activeParty[4] = activeParty[5];
                    activeParty[4].titanPosition = 4;

                    activeParty[5] = null;
                }
                else if (i == 4)
                {
                    activeParty[4] = activeParty[5];
                    activeParty[4].titanPosition = 4;

                    activeParty[5] = null;
                }
                else
                {
                    activeParty[5] = null;
                }
            }
        }

        // End Phase
        // Activates enemy's end of turn ability (if applicable)
        enemy.OnEndTurn(activeParty, enemy);
        // Activates party's end of turn abilities (if applicable)
        for (int i = 0; i < activeParty.Count; i++)
        {
            if (activeParty[i] != null)
            {
                activeParty[i].OnEndTurn(activeParty, enemy);
            }
        }
    }

    public void EndBattle()
    {
        Debug.Log("You win!");
        Destroy(battleButton);
    }
}
