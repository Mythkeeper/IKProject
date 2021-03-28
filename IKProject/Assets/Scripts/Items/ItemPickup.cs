using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
   //  [SerializeField] int sceneToLoad=-1;
    public Item item;
    private bool playerDetected;
    public Transform doorPos;
    public float width;
    public float height;
    public LayerMask whatIsPlayer;
    //public Animator transition;
   // public Vector2 playerPosition;
   //public Position playerMemory;

    // Update is called once per frame

    // care , destroys the item always if not accounted for
   private void Update()
    {
      playerDetected=Physics2D.OverlapBox(doorPos.position, new Vector2(width,height), 0 , whatIsPlayer);

      if(playerDetected==true){
        if(Input.GetKeyDown(KeyCode.E)){
            print("Picking up"+ item.name); // testing
           bool wasPickedUp =Inventory.instance.Add(item);
           if (wasPickedUp){
               Destroy(gameObject);
           }
            
        }
      }
    }
    private void OnDrawGizmosSelected(){
      Gizmos.color=Color.blue;
      Gizmos.DrawWireCube(doorPos.position, new Vector3(width, height, 1));
    }
}
