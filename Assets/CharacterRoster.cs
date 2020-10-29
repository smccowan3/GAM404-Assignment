using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class CharacterRoster : MonoBehaviour
{
    public Character[] CharArray;
    // Start is called before the first frame update
    public void makeCharacters()
    {
        CharArray = new Character[15];
        Debug.Log("Now presenting all the characters ready to battle today...");
        for (int i = 0; i < 15; i++)
        {
            CharArray[i] = new Character();
            CharArray[i].setVals(i);
        }
    }
    public void setPickedTrue(int charNum)
    {
        CharArray[charNum].picked = true;
    }

}

public class Character
{
    public bool picked = false;
    public string first_name;
    public string last_name;
    public bool alive = true;
    public int dexterity;
    public int stamina;
    public int strength;
    public int acuity;
    private int dodge_chance;
    private int health;
    private int damage;
    private int crit_chance;
    public double curr_health;
    public double attack()
    {
        double total_damage;
        double multip = 1;
        //first find if crit
        int critScore = UnityEngine.Random.Range(1, 100);
        if (critScore <= crit_chance)
        {
            multip = 2;
            Debug.Log(first_name + " " + last_name + " has successfully crit! Double damage has been inflicted");
        }
        total_damage = damage * multip;
        Debug.Log(first_name + " " + last_name + " has dealt " + total_damage + " damage");
        return total_damage;
    }
    public void defend(double dmg)
    {
        int dodgeScore = UnityEngine.Random.Range(1, 100);
        if (dodgeScore <= dodge_chance)
        {
            Debug.Log(first_name + " " + last_name + " has successfully dodged! No damage has been taken");
        }
       else
        {
            Debug.Log(first_name + " " + last_name + " has failed to dodge and taken " + dmg + " damage");
            curr_health = curr_health - dmg;
            if (curr_health > 0)
            {
                Debug.Log("Remaining health is: " + curr_health);
            }
            else if (curr_health <= 0)
            {
                Debug.Log("Oh no! " + first_name + " " + last_name + " has died! They can no longer fight");
                alive = false;
            }
        }
    }
    public void setVals(int charNum)
    {
        charNum = charNum + 1; // print 1 not zero
        string[] firstnamelist = File.ReadAllLines("first_names.txt");
        int rnd = UnityEngine.Random.Range(0, firstnamelist.Length);
        first_name = firstnamelist[rnd];
        string[] lastnamelist = File.ReadAllLines("last_names.txt");
        int rnd2 = UnityEngine.Random.Range(0, lastnamelist.Length);
        last_name = lastnamelist[rnd2];
       
        dexterity = UnityEngine.Random.Range(1, 100);
        stamina = UnityEngine.Random.Range(1, 100);
        strength = UnityEngine.Random.Range(1, 100);
        acuity = UnityEngine.Random.Range(1, 100);
        dodge_chance = dexterity / 500;
        health = stamina*2;
        damage = strength;
        crit_chance = acuity / 500;
        curr_health = health;
        Debug.Log("Character " + charNum + " is " + first_name + " " + last_name + " with a dexterity of " 
            + dexterity + ", a stamina of " + stamina + ", a strength of " + strength + ", and an acuity of " + acuity + ".");
    }
}