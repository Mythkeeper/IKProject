
using UnityEngine;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour
{   
    public Image icon; //Sprite var
    Item item; //Item ref

    //Function to Add item
    public void AddItem(Item newItem)
    {
        item=newItem;
        icon.sprite=item.icon;
        icon.enabled=true;
    }

    //Fucntion to clear slot
    public void ClearSlot ()
    {
        item=null;
        icon.sprite=null;
        icon.enabled=false;
    }

    //Funcntion to use item
    public void UseItem()
    {
        if(item != null)
        {
            item.Use();
        }
    }
}
