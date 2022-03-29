using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestBattle : MonoBehaviour
{
    [SerializeField] Party partyClass;
    public Titan enemy;
    List<Titan> activeParty;
    [SerializeField] GameObject battleButton;
    private bool battling;
    public GameObject[] landingSpots;
    public GameObject endScreen;
    public TextMeshPro endScreenText;

    // Start is called before the first frame update
    void Start()
    {
        activeParty = partyClass.activeParty;
        battling = true;
    }

    private void Update()
    {
        // Pushes battle forward
        if (Input.GetKeyUp(KeyCode.M) && battling)
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
        enemy.TestAttack(activeParty);
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
            if (activeParty[i] != null && activeParty[i].DeathCheck(activeParty, enemy) == true)
            {
                if (i == 0)
                {
                    if (activeParty[1] != null)
                    {
                        activeParty[0] = activeParty[1];
                        activeParty[0].titanPosition = 0;
                        activeParty[0].transform.position = landingSpots[0].transform.position;
                    }
                    else
                    {
                        activeParty[0] = null;
                    }

                    if (activeParty[2] != null)
                    {
                        activeParty[1] = activeParty[2];
                        activeParty[1].titanPosition = 1;
                        activeParty[1].transform.position = landingSpots[1].transform.position;
                    }
                    else
                    {
                        activeParty[1] = null;
                    }


                    activeParty[2] = null;
                }
                else if (i == 1)
                {
                    if (activeParty[2] != null)
                    {
                        activeParty[1] = activeParty[2];
                        activeParty[1].titanPosition = 1;
                        activeParty[1].transform.position = landingSpots[1].transform.position;

                    }
                    else
                    {
                        activeParty[1] = null;
                    } 

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
            if (activeParty[i] != null && activeParty[i].DeathCheck(activeParty, enemy) == true)
            {
                if (i == 3)
                {
                    if (activeParty[4] != null)
                    {
                        activeParty[3] = activeParty[4];
                        activeParty[3].titanPosition = 3;
                        activeParty[3].transform.position = landingSpots[3].transform.position;
                    }
                    else
                    {
                        activeParty[3] = null;
                    }

                    if (activeParty[5] != null)
                    {
                        activeParty[4] = activeParty[5];
                        activeParty[4].titanPosition = 4;
                        activeParty[4].transform.position = landingSpots[4].transform.position;
                    }
                    else
                    {
                        activeParty[4] = null;
                    }


                    activeParty[5] = null;
                }
                else if (i == 4)
                {
                    if (activeParty[5] != null)
                    {
                       activeParty[4] = activeParty[5];
                       activeParty[4].titanPosition = 4;
                       activeParty[4].transform.position = landingSpots[4].transform.position;
                    }
                    else
                    {
                        activeParty[4] = null;
                    }

                   

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

        for (int i = 0; i < activeParty.Count; i++)
        {
            if (activeParty[i] != null)
            {
                activeParty[i].UpdateUI();
            }
        }
        enemy.UpdateUI();
    }

    public void EndBattle()
    {
        endScreenText.text = "You Win!";
        endScreen.transform.position = Vector3.zero;
        Debug.Log("You win!");
        Destroy(battleButton);
        battling = false;
    }
}
