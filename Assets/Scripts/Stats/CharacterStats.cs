using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterStats : MonoBehaviour
{
<<<<<<< HEAD
    
    public Stat damage;
    public Stat armor;
    public int currentHealth ; 
=======
    public Stat damage;
    public Stat armor;
    public int currentHealth ; // can get this value from anywhere but only set it in here
>>>>>>> a7a94dba4fb262a58d76dc93bbefb285fbd7bdec
    public int maxHealth; // number of health conatiners
   
    void Awake()
    {
        
        currentHealth=maxHealth;;
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(2);
        }
    }
<<<<<<< HEAD
   
=======

>>>>>>> a7a94dba4fb262a58d76dc93bbefb285fbd7bdec
    public void TakeDamage(int damage)
    {
        damage -=armor.GetValue();
        damage=Mathf.Clamp(damage,0, int.MaxValue);
        currentHealth-=damage;
        Debug.Log("took dmg"+damage);
        if (currentHealth<=0)
        {
            Die();
<<<<<<< HEAD
            
=======
>>>>>>> a7a94dba4fb262a58d76dc93bbefb285fbd7bdec
        }
    }
    public virtual void Die()
    {
        //die in some way
        //will override
        Debug.Log("died");
<<<<<<< HEAD
        
=======
>>>>>>> a7a94dba4fb262a58d76dc93bbefb285fbd7bdec
    }
}
