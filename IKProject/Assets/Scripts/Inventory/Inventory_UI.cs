
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{
    public Transform itemsParent; //inventory slots parent object
    Inventory inventory; //create inventory
    public GameObject inventoryUI; //UI creation
    InventorySlot[] slots; //slots array

    // Start is called before the first frame update
    void Start()
    {
        inventory=Inventory.instance; //reference to inv instance through singleton
        inventory.onItemChangedCallback +=UpdateUI; 
        slots= itemsParent.GetComponentsInChildren<InventorySlot>(); //get slot component
        //inventoryUI.SetActive(false); //start with UI disabled DELETE IF YOU FOUND A WAY THROUGH THE INSPECTOR!!!
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory")) //Edit buttons through the edit in unity
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf); //set UI to active
        }
    }

    //Function to update UI
    void UpdateUI () 
    {
        Debug.Log("update ui");
        // loop through all slots  to check if there are more items to add
        for (int i=0; i<slots.Length; i++)
        {
            if (i<inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }else{
               slots[i].ClearSlot();
            }
        }
    }
}
