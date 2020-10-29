using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSim : MonoBehaviour
{
    public GameObject team1;
    public GameObject team2;
    public GameObject cRoster;
    private Team t1;
    private Team t2;
    private CharacterRoster cR;
    private Character[] atkTeam;
    private Character[] defTeam;

    public void runBattle()
    {
        int attackChar= 0, defChar = 0;
        double dmg;
        atkTeam = new Character[5];
        defTeam = new Character[5];
        string atkString, defString;
        int round = 1;
        while (t1.isAlive() == true && t2.isAlive() == true)
        {
            //first randomise turn
            if (round == 1)
            {
                Debug.Log("Now beginning battle round: " + round);
                int firstTurn = UnityEngine.Random.Range(1, 2);
                Debug.Log("Team " + firstTurn + " has won the first turn. But remember damage is reduced by 30% for first two turns");
                if (firstTurn == 1)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        atkTeam[i] = t1.teamCharArray[i];
                        atkString = "Team 1";
                        defTeam[i] = t2.teamCharArray[i];
                        defString = "Team 2";
                    }
                }
                else if (firstTurn == 2)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        atkTeam[i] = t1.teamCharArray[i];
                        atkString = "Team 2";
                        defTeam[i] = t2.teamCharArray[i];
                        defString = "Team 1";
                    };
                }
                //now first round
                //first turn team attacks
                attackChar = UnityEngine.Random.Range(0, 5);
                dmg = atkTeam[attackChar].attack();
                dmg = dmg * 0.7; //first round modifier
                defChar = UnityEngine.Random.Range(0, 5);
                defTeam[defChar].defend(dmg);
                //second turn team attacks. need to check if dead
                for (int i = 0; i < 1; i++)
                {
                    defChar = UnityEngine.Random.Range(1, 5);
                    if (defTeam[defChar].alive == false)
                    {
                        i--; //reroll if dead
                    }
                }
                dmg = defTeam[defChar].attack();

                for (int i = 0; i < 1; i++)
                {
                    attackChar = UnityEngine.Random.Range(1, 5);
                    if (atkTeam[attackChar].alive == false)
                    {
                        i--; //reroll if dead
                    }
                }
                atkTeam[attackChar].defend(dmg);
                round++;
            }



            //now start subsequent rounds
            Debug.Log("Now beginning battle round: " + round);
            
            //team that went first attacks
            for (int i = 0; i < 1; i++)
            {
                attackChar = UnityEngine.Random.Range(0, 5);
                if (atkTeam[attackChar].alive == false)
                {
                    i--; //reroll if dead
                }
            }
            dmg = atkTeam[attackChar].attack();
            if (round == 2)
            {
                dmg = dmg * 0.7;
            }

        
            for (int i = 0; i < 1; i++)
            {
                defChar = UnityEngine.Random.Range(0, 5);
                if (atkTeam[defChar].alive == false)
                {
                    i--; //reroll if dead
                }
            }
            defTeam[defChar].defend(dmg);

            //team that went second attacks
            for (int i = 0; i < 1; i++)
            {
                defChar = UnityEngine.Random.Range(1, 5);
                if (atkTeam[defChar].alive == false)
                {
                    i--; //reroll if dead
                }
            }
            dmg = defTeam[defChar].attack();

            for (int i = 0; i < 1; i++)
            {
                attackChar = UnityEngine.Random.Range(1, 5);
                if (atkTeam[attackChar].alive == false)
                {
                    i--; //reroll if dead
                }
            }
           atkTeam[attackChar].defend(dmg);



            round++;
            if (round > 40)
            {
                break;
            }
        }
        if (t1.isAlive() == false)
        {
            Debug.Log("Well that's it! Team 1's members are all dead. Team 2 Wins!");
        }
        else if (t2.isAlive() == false)
        {
            Debug.Log("Well that's it! Team 2's members are all dead. Team 1 Wins!");
        }
    }
    public void setTeams()
    {
        cR = cRoster.GetComponent<CharacterRoster>();
        cR.makeCharacters();
        t1 = team1.GetComponent<Team>();
        t1.chooseCharacters();
        t2 = team2.GetComponent<Team>();
        t2.chooseCharacters();
    }
    // Start is called before the first frame update
    void Start()
    {
        setTeams();
        runBattle();
    }
}
