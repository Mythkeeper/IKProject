using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance; //accessible instance at all times

    void Awake ()
    {
        if(instance !=null)
        {
            Debug.LogWarning("More than one instance open");
            return;
        }

        instance= this; // setting the instace to this component when starting the game
    }

    #endregion

    //delegate  event--> subscribe different methods to and when called all methods are called
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    public int space=20; // inv space

    public List<Item> items= new List<Item>(); //Item array


    // method to add item to inv, bool type so that we dont destroy the item through pickup
    public bool Add (Item item)
    {
      if(!item.isDefaultItem)
      {
          if (items.Count >=space)
          {
              Debug.Log("No room."); // no room if there is no space in inv
              return false;
          }
          items.Add (item); // add item to list
          if(onItemChangedCallback != null)
          {
            onItemChangedCallback.Invoke(); // trigger event UI update
          }
          
      }
      return true;
      
    }

    //method to remove item from inentory...DK if it will be used
    public void Remove(Item item)
    {

        items.Remove(item); // remove from list
        Debug.Log("Removed");
        

        if(onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke(); // trigger event UI update
        }
    }

}