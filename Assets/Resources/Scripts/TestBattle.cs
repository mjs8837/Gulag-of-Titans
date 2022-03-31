using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestBattle : MonoBehaviour
{
    [SerializeField] Party partyClass;
    public Titan enemy;
    public List<Titan> activeParty;
    private bool battling;
    private bool gameOver;
    public GameObject[] landingSpots;
    public GameObject endScreen;
    public TextMeshPro endScreenText;

    [SerializeField] SpriteRenderer stateBox;
    [SerializeField] TextMeshPro stateText;

    public bool firstTurn;

    // Start is called before the first frame update
    void Start()
    {
        firstTurn = true;
        activeParty = partyClass.activeParty;
        gameOver = false;

        // Defaults the player to battling
        battling = false;
        SwitchState();

        // Sets up max swaps and displays counter
        partyClass.maxSwaps = 2;
        partyClass.currentSwaps = partyClass.maxSwaps;
        partyClass.UpdateCounter();
    }

    private void Update()
    {
        if (!gameOver)
        {
            if (firstTurn == true)
            {
                for (int i = 0; i < activeParty.Count; i++)
                {
                    activeParty[i].OnAppear(activeParty, enemy);
                }
                firstTurn = false;
                enemy.UpdateUI();
            }

            // Pushes battle forward
            if (Input.GetKeyUp(KeyCode.M) && battling)
            {
                Turn();
            }
            // Switches states
            if (Input.GetKeyUp(KeyCode.R))
            {
                SwitchState();
            }
            // Manually unlocks party
            if (Input.GetKeyUp(KeyCode.L))
            {
                partyClass.unlocked = !(partyClass.unlocked);
            }
            if (Input.GetKeyUp(KeyCode.H))
            {
                enemy.health += 10;
                enemy.UpdateUI();
            }
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
        if (activeParty[0] != null)
        {
            activeParty[0].Attack(enemy, activeParty[0].damage);
            activeParty[0].stamina--;
        }
        if (activeParty[3] != null)
        {
            activeParty[3].Attack(enemy, activeParty[3].damage);
            activeParty[3].stamina--;
        }
        // Death Phase
        // Checks if the enemy is dead and ends the battle if so
        if (enemy.DeathCheck(activeParty, enemy))
        {
            WinBattle();
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
        // Updates enemy's UI
        enemy.UpdateUI();
        // Gives the player a swap if they haven't reached the limit
        if (partyClass.currentSwaps < partyClass.maxSwaps)
        {
            partyClass.currentSwaps++;
            partyClass.UpdateCounter();
        }
        // Checks if there are any members in the party
        if (CheckLoss(activeParty))
        {
            // Loses battle if so
            LoseBattle();
        }
    }

    // Switches the player between battling and swapping
    public void SwitchState()
    {
        // Switchs boolean
        battling = !battling;
        if (battling)
        {
            // Changes color and text
            stateBox.color = new Color32(250, 165, 55, 255);
            stateText.text = "Battling!";
            // Locks the party
            partyClass.unlocked = false;
            
        }
        else
        {
            // Changes color and text
            stateBox.color = new Color32(170, 51, 255, 255);
            stateText.text = "Swapping!";
            // Unlocks the party and reverses battling boolean
            partyClass.unlocked = true;
            battling = false;
        }
        
    }

    // Displays win screen
    public void WinBattle()
    {
        // Edits the end screen text and moves it to the player's view
        endScreenText.text = "You Win!";
        endScreen.transform.position = Vector3.zero;
        battling = false;
    }

    // Checks if there are any party members still in the array
    public bool CheckLoss(List<Titan> activeParty)
    {
        for (int i = 0; i < activeParty.Count; i++)
        {
            if (activeParty[i] != null)
            {
                // If there is then the player did not lose
                return false;
            }
        }
        // If there isn't then they did lose
        return true;
    }

    // Displays lsoe screen
    public void LoseBattle()
    {
        // Edits the end screen text and moves it to the player's view
        endScreenText.text = "You Lose!";
        endScreen.transform.position = Vector3.zero;
        battling = false;
    }
}
