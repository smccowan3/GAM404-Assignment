using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Teams : MonoBehaviour { 
    public string[] rawnamelist;
    public class Character
    {
        public string name;
        public int dexterity;
        public int stamina;
        public int strength;
        public int acuity;
        private int dodge_chance;
        private int health;
        private int damage;
        private int crit_chance;
        public int curr_health;
        public Character()
        {
            string[] namelist = File.ReadAllLines("character_names_rewr.txt");
            Debug.Log(namelist.Length);
            int rnd = UnityEngine.Random.Range(0, namelist.Length);
            name = namelist[rnd];
            Debug.Log(name);
            string[] newnameList;
            for (int i = 0; i < namelist.Length; i++)
            {
                if (i != rand)
                {
                    if (i == newnameList.length)
                    {
                        newnameList[i] = namelist[i];
                    }
                    else if (i != newnameList.length)
                    {
                        newnameList[i-1] = namelist[i];
                    }
                    
                }  
            }
            System.IO.File.WriteAllLines("character_names_rewr.txt", newnameList);
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
        public int getBattleAttributes()
        {
            return 0;
        }
    }
    public Teams()
    {
       rawnameList = File.ReadAllLines("character_names.txt");
       System.IO.File.WriteAllLines("character_names_rewr.txt", rawnameList);
       Character c1, c2, c3, c4, c5, c6, c7, c8, c9, c10 = new Character();
    }
    // Start is called before the first frame update
    void Start()
    {
        Teams t1,t2 = new Teams(); 
    }
}
