using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{

    [SerializeField] Party partyClass;
    [SerializeField] Titan enemy;
    Titan[] activeParty;
    // Start is called before the first frame update
    void Start()
    {
        activeParty = partyClass.activeParty;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Turn()
    {
        

        //Beginning Phase

        enemy.OnBeginTurn();
        for (int i = 0; i < activeParty.Length; i++)
        {
            activeParty[i].OnBeginTurn();
        }

        //WAIT 

        //Attack Phase

        enemy.Attack(activeParty);
        activeParty[0].Attack(enemy, activeParty[0].damage);
        activeParty[3].Attack(enemy, activeParty[3].damage);


        //WAIT 
        //End turn Phase

        Titan[] tempParty = activeParty;
        enemy.DeathCheck();

        for(int i = 0; i < 3; i++){
            if(activeParty[i] == null)
            {
             
            }
            else if(activeParty[i].DeathCheck() == true){
                activeParty[i].OnDeath();
                if (i == 0)
                {
                    activeParty[0] = activeParty[1];
                    activeParty[1] = activeParty[2];
                    activeParty[2] = null;
                }
                else if(i == 1)
                {
                    activeParty[1] = activeParty[2];
                    activeParty[2] = null;
                }
                else
                {
                    activeParty[2] = null;
                }
                i--;
                
            }

        }
        for(int i = 3; i < 5; i++){

            if (activeParty[i] == null)
            {

            }
            else if (activeParty[i].DeathCheck() == true)
            {
                activeParty[i].OnDeath();
                if (i == 0)
                {
                    activeParty[3] = activeParty[4];
                    activeParty[4] = activeParty[5];
                    activeParty[5] = null;
                }
                else if (i == 1)
                {
                    activeParty[4] = activeParty[4];
                    activeParty[5] = null;
                }
                else
                {
                    activeParty[5] = null;
                }
                i--;

            }
        }
       

    }

    public void EndBattle()
    {

    }
}