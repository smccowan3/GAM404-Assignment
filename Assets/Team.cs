using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team : MonoBehaviour
{
    public Character[] teamCharArray;
    public GameObject Character_Roster;
    public int teamNum;
    private CharacterRoster charRosterScript;
    private Character[] charRoster;
    // Start is called before the first frame update
    public void chooseCharacters()
    {
        charRosterScript = Character_Roster.GetComponent<CharacterRoster>();
        charRoster = Character_Roster.GetComponent<CharacterRoster>().CharArray;
        int charNum, rnd;
        teamCharArray = new Character[15];
        Debug.Log("Now team " + teamNum + " will make their selection...");
        for (int i = 0; i< 5; i++)
        {
            rnd = UnityEngine.Random.Range(1, 15); //pick rand character
            if (charRoster[rnd].picked == false)
            {
                teamCharArray[i] = charRoster[rnd];
                charRosterScript.setPickedTrue(rnd);
                charNum = i + 1;
                Debug.Log("Team " + teamNum + " Character " + (charNum) + " is " + charRoster[rnd].first_name +
                    " " + charRoster[rnd].last_name);
            }
            else if (charRoster[rnd].picked == true)
            {
                i--; // this will rerun loop
            }
        }

    }

    public bool isAlive() //tests if any characters are alive
    {
        bool teamAlive = true;
        int deadScore = 0;
        for (int i = 0; i<5; i++)
        {
            if (teamCharArray[i].alive == false)
            {
                deadScore++;  
            }
        }
        //Debug.Log("Team " + teamNum + " has " + deadScore + " dead members");
        if (deadScore == 5)
        {
            //Debug.Log("Team " + teamNum + "'s members are all dead");
            teamAlive = false;
        }
        return teamAlive;
    }
}
