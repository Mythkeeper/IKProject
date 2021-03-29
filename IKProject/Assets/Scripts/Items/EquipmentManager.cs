using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{

    #region Singleton

    public static EquipmentManager instance;
    

    void Awake()
    {
        instance = this;
    }

    #endregion
    Inventory inventory;
    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;
    Equipment[] currentEquipment; //array hold current equipment


    void Start()
    {
    
        inventory=Inventory.instance;
        int numSlots=  System.Enum.GetNames(typeof(EquipmentSlot)).Length; //string array of all the elemtns in the inventory slot enum
        currentEquipment = new Equipment[numSlots];
    }


    //Fucntion to equip item !! slot matters !!
    public void Equip(Equipment newItem)
    {
        int slotIndex=(int)newItem.eqSlot;
        Equipment oldItem=null;
        if(currentEquipment[slotIndex] !=null) //if something is already equipped
        {   
            oldItem=currentEquipment[slotIndex]; //if old item at the position new item is acessing
            //add item back into the inventory
            inventory.Add(oldItem);
        }

        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }
        currentEquipment[slotIndex] = newItem;
        
    }

    public void Unequip (int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
        Equipment oldItem=currentEquipment[slotIndex];
        inventory.Add(oldItem);

        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(null, oldItem);
        }
        currentEquipment[slotIndex]= null;
        }
    }


    public void UnequipAll()
    {
        for (int i=0; i<currentEquipment.Length; i++)
        {
            Unequip(i);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U)){
            UnequipAll();
        }
    }
}
