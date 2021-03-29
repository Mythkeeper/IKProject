using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "New Item", menuName="Inventory/Item")] //to be able to create new objects of type item
public class Item : ScriptableObject
{
    new public string name="New Item"; //name var
    public Sprite icon= null; //sprite var
    public bool isDefaultItem= false; // default item if there is any

    //function for when we use the item
    //virtual void because different items do different things on use
    public virtual void Use()
    {

        // something may happen 
        //use hte item
        Debug.Log("Using" +name);
    }
    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }
}
