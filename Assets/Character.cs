using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Character : MonoBehaviour
{
    string char_name;
    public int dexterity;
    public int stamina;
    public int strength;
    public int acuity;
    private int dodge_chance;
    private int health;
    private int damage;
    private int crit_chance;
    public int curr_health;
    void Start()
    {
        string[] namelist = File.ReadAllLines("character_names.txt");
        Debug.Log(namelist.Length);
        int rnd = UnityEngine.Random.Range(0, namelist.Length);
        char_name = namelist[rnd];
        Debug.Log("Character Name is " + char_name);
        dexterity = UnityEngine.Random.Range(1, 100);
        stamina = UnityEngine.Random.Range(1, 100);
        strength = UnityEngine.Random.Range(1, 100);
        acuity = UnityEngine.Random.Range(1, 100);
        dodge_chance = dexterity / 100;
        health = stamina * 10;
        damage = strength;
        crit_chance = acuity / 100;
        curr_health = health;
    }
}

