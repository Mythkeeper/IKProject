using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Item types enumerator
public enum ItemType
{
    
    Equipment,
    Default
}

public enum Attributes
{
    Agility,
    Intellect,
    Stamina,
    Strength
}

//all other object types regarding items will derive and inherit from this class
public abstract class Item : ScriptableObject
{
 
    public ItemType type;
    [TextArea(15, 20)] //to give the description space
    public string description;
  

   
}




