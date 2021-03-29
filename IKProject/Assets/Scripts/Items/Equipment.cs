using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "New Equipment",menuName="Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot eqSlot; //equipemtn slot var
    public int armorMod; //armor modifier
    public int dmgMod; //damage modifier

    public override void Use(){
        base.Use();
        EquipmentManager.instance.Equip(this);
        RemoveFromInventory();
    }




}

//Use this enum in multiple places not just this class
public enum EquipmentSlot {AttackCharm,DefenseCharm,EffectCharm}