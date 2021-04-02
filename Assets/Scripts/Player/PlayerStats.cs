using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : CharacterStats
{

    public int numOfMasks;
    public Image[] masks; 
    public Sprite fullmask;
    public Sprite emptymask;
    
    // Start is called before the first frame update
    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged +=OnEquipmentChanged;
        numOfMasks=4;
        currentHealth=numOfMasks;
    }


    // Update is called once per frame
    void Update()
    {
        //so that there is no overheal
        if(currentHealth >numOfMasks){
            currentHealth = numOfMasks;

        }
        //for displaying the UI
        for(int i = 0;i< masks.Length; i++){

            if(i<currentHealth){
                masks[i].sprite=fullmask;
            } else {
                masks[i].sprite=emptymask;
            }

            if(i<numOfMasks){
            masks[i].enabled=true;
        }
        else {
            masks[i].enabled=false;
        }
     }
     if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(2);
        }
    }

//Update stats when equipment is changed.
    void OnEquipmentChanged (Equipment newItem, Equipment oldItem)
    {
        if(newItem !=null)
        {
            armor.UpdateStats(newItem.armorMod); 
            damage.UpdateStats(newItem.dmgMod);
        }  
        if (oldItem !=null)    
        {
             armor.RemoveStats(oldItem.armorMod);
             damage.RemoveStats(oldItem.dmgMod);
        }
        
    }
}
