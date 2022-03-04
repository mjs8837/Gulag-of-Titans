using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Battle : MonoBehaviour
{

    [SerializeField] Party partyClass;
    [SerializeField] Titan enemy;
    List<Titan> activeParty;

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

        enemy.OnBeginTurn(activeParty, enemy);
        for (int i = 0; i < activeParty.Count; i++)
        {
            if (activeParty[i] != null)
            {
                activeParty[i].OnBeginTurn(activeParty, enemy);
            }
        }

        //WAIT 

        //Attack Phase

        enemy.Attack(activeParty);
        activeParty[0].Attack(enemy, activeParty[0].damage);
        activeParty[3].Attack(enemy, activeParty[3].damage);


        //WAIT 
        //End turn Phase

        //Deaths
        enemy.DeathCheck(activeParty, enemy);

        for(int i = 0; i < 3; i++){
            if(activeParty[i] == null)
            {
             
            }
            else if(activeParty[i].DeathCheck(activeParty, enemy) == true){
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
        for(int i = 3; i < 6; i++){

            if (activeParty[i] == null)
            {

            }
            else if (activeParty[i].DeathCheck(activeParty, enemy) == true)
            {
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
        //End of turn abilities
        for(int i = 0; i < 6; i++)
        {
            if(activeParty[i] == null)
            {

            }
            else
            {
                activeParty[i].OnEndTurn(activeParty, enemy);
            }
        }
       

    }

    public void EndBattle()
    {

    }
}
