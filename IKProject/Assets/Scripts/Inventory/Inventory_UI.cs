
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{
    public Transform itemsParent;
    Inventory inventory;
    public GameObject inventoryUI;

    InventorySlot[] slots;
    // Start is called before the first frame update
    void Start()
    {
        inventory=Inventory.instance;
        inventory.onItemChangedCallback +=UpdateUI;

        slots= itemsParent.GetComponentsInChildren<InventorySlot>();
        inventoryUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory")){
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }

    void UpdateUI () {
        Debug.Log("update ui");
        // loop through all slots  to check if there are more items to add
        for (int i=0; i<slots.Length; i++){

            if (i<inventory.items.Count){
                slots[i].AddItem(inventory.items[i]);
            }//else{
               // slots[i].ClearSlot();
           // }
        }
    }
}
