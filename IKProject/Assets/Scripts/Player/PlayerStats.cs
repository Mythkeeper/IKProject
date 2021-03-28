using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerStats : MonoBehaviour
{
    public int health;
    public int numOfMasks; // number of health conatiners
    public Image[] masks; 
    public Sprite fullmask;
    public Sprite emptymask;
    // Update is called once per frame
    void Update()
    {

        if(health >numOfMasks){
            health = numOfMasks;

        }
        for(int i = 0;i< masks.Length; i++){

            if(i<health){
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
        
    }
}
