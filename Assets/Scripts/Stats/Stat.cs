using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat 
{
   [SerializeField] private int baseValue; //stat base value editable through inspector

    private List<int> modifiers = new List<int>(); //manage stat modifiers list
    public int GetValue() 
    {
        int FValue=baseValue;
        modifiers.ForEach(y=> FValue+=y); //faster than looping
        return FValue;
    }

    public void UpdateStats (int modifier)
    {
        //if modifier is not 0 then add the modifier
        if (modifier !=0)
        {
            modifiers.Add(modifier);
        }
    }
    public void RemoveStats (int modifier)
    {
        if (modifier !=0)
        {
            modifiers.Remove(modifier);
        }
    }
}
