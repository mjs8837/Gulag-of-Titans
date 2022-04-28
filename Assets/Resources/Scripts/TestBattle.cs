using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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

    public bool firstTurn;

    // Start is called before the first frame update
    void Start()
    {
        firstTurn = true;
        activeParty = partyClass.activeParty;
        gameOver = false;

        // Defaults the player to battling
        battling = true;

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
            if (Input.GetKeyUp(KeyCode.R) && battling)
            {
                Turn();
            }
            // Give enemy more health (debugging)
            if (Input.GetKeyUp(KeyCode.H))
            {
                enemy.health += 10;
                enemy.UpdateUI();
            }
            // Test
            if (Input.GetKeyUp(KeyCode.T))
            {
                
            }
            // List titans (debugging)
            if (Input.GetKeyUp(KeyCode.L))
            {
                for (int i = 0; i < 6; i++)
                {
                    if (activeParty[i] != null)
                    {
                        Debug.Log("Member " + (i + 1) + ": " + activeParty[i]);
                    }
                    else
                    {
                        Debug.Log("Member " + (i + 1) + ": null");
                    }
                }
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

        // Checks to move up top row
        for (int i = 0; i < 3; i++)
        {
            if (activeParty[i] == null)
            {
                if (i == 0)
                {
                    if (activeParty[1] != null && activeParty[2] != null)
                    {
                        activeParty[0] = activeParty[1];
                        activeParty[0].titanPosition = 0;
                        activeParty[0].transform.position = landingSpots[0].transform.position;

                        activeParty[1] = activeParty[2];
                        activeParty[1].titanPosition = 1;
                        activeParty[1].transform.position = landingSpots[1].transform.position;

                        activeParty[2] = null;
                    }
                    else if (activeParty[1] == null && activeParty[2] != null)
                    {
                        activeParty[0] = activeParty[2];
                        activeParty[0].titanPosition = 0;
                        activeParty[0].transform.position = landingSpots[0].transform.position;

                        activeParty[2] = null;
                    }
                    else if (activeParty[1] != null && activeParty[2] == null)
                    {
                        activeParty[0] = activeParty[1];
                        activeParty[0].titanPosition = 0;
                        activeParty[0].transform.position = landingSpots[0].transform.position;

                        activeParty[1] = null;
                    }
                }
                else if (i == 1)
                {
                    if (activeParty[0] != null && activeParty[2] != null)
                    {
                        activeParty[1] = activeParty[2];
                        activeParty[1].titanPosition = 1;
                        activeParty[1].transform.position = landingSpots[1].transform.position;

                        activeParty[2] = null;
                    }
                    if (activeParty[0] == null && activeParty[2] != null)
                    {
                        activeParty[0] = activeParty[2];
                        activeParty[0].titanPosition = 0;
                        activeParty[0].transform.position = landingSpots[0].transform.position;

                        activeParty[2] = null;
                    }
                }
            }
        }

        // Checks to move up bottom row
        for (int i = 3; i < 6; i++)
        {
            if (activeParty[i] == null)
            {
                if (i == 3)
                {
                    if (activeParty[4] != null && activeParty[5] != null)
                    {
                        activeParty[3] = activeParty[4];
                        activeParty[3].titanPosition = 3;
                        activeParty[3].transform.position = landingSpots[3].transform.position;

                        activeParty[4] = activeParty[5];
                        activeParty[4].titanPosition = 4;
                        activeParty[4].transform.position = landingSpots[4].transform.position;

                        activeParty[5] = null;
                    }
                    else if (activeParty[4] == null && activeParty[5] != null)
                    {
                        activeParty[3] = activeParty[5];
                        activeParty[3].titanPosition = 3;
                        activeParty[3].transform.position = landingSpots[3].transform.position;

                        activeParty[5] = null;
                    }
                    else if (activeParty[4] != null && activeParty[5] == null)
                    {
                        activeParty[3] = activeParty[4];
                        activeParty[3].titanPosition = 3;
                        activeParty[3].transform.position = landingSpots[3].transform.position;

                        activeParty[4] = null;
                    }
                }
                else if (i == 4)
                {
                    if (activeParty[3] != null && activeParty[5] != null)
                    {
                        activeParty[4] = activeParty[5];
                        activeParty[4].titanPosition = 4;
                        activeParty[4].transform.position = landingSpots[4].transform.position;

                        activeParty[5] = null;
                    }
                    if (activeParty[3] == null && activeParty[5] != null)
                    {
                        activeParty[3] = activeParty[5];
                        activeParty[3].titanPosition = 3;
                        activeParty[3].transform.position = landingSpots[3].transform.position;

                        activeParty[5] = null;
                    }
                }
            }
        }

        // Attack Phase
        // Enemy attacks party
        enemy.TestAttack(activeParty);
        // Front two members attack enemy
        if (activeParty[0] != null)
        {
            activeParty[0].Attack(enemy, activeParty[0].damage);
        }
        if (activeParty[3] != null)
        {
            activeParty[3].Attack(enemy, activeParty[3].damage);
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

        for (int i = 0; i < activeParty.Count; i++)
        {
            if (activeParty[i] != null)
            {
                activeParty[i].CheckHurt();
            }
        }
        if (enemy != null)
        {
            enemy.CheckHurt();
        }
    }

    // Displays win screen
    public void WinBattle()
    {
        // Edits the end screen text and moves it to the player's view
        endScreenText.text = "You Win!";
        endScreen.transform.position = Vector3.zero;
        battling = false;

        Invoke("BattleSceneChange", 2);
    }

    private void BattleSceneChange()
    {
        SceneManager.LoadScene("Map");
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

        Invoke("BattleSceneChange", 2);
    }

    IEnumerator Test()
    {
        Debug.Log("Start" + Time.time);

        yield return new WaitForSeconds(3);

        Debug.Log("PPee" + Time.time);
    }
}
