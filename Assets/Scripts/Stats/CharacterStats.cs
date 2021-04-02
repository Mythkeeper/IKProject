using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterStats : MonoBehaviour
{
    
    public Stat damage;
    public Stat armor;
    public int currentHealth ; 
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
   
    public void TakeDamage(int damage)
    {
        damage -=armor.GetValue();
        damage=Mathf.Clamp(damage,0, int.MaxValue);
        currentHealth-=damage;
        Debug.Log("took dmg"+damage);
        if (currentHealth<=0)
        {
            Die();
            
        }
    }
    public virtual void Die()
    {
        //die in some way
        //will override
        Debug.Log("died");
        
    }
}
