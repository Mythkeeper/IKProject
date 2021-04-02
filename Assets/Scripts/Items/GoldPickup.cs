using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickup : MonoBehaviour
{
    public int pickupQuantity;
    public GameObject knight;
   
    
    private bool playerDetected; //detect player boolean
    public Transform doorPos; //transofrm copied from portal script
    public float width; //width of transform  
    public float height; //height of transform
    public LayerMask whatIsPlayer; //anything on the player layer is considered a player object
   

    // Update is called once per frame
    // care , destroys the item always if not accounted for
   private void Update()
    {
      
      playerDetected=Physics2D.OverlapBox(doorPos.position, new Vector2(width,height), 0 , whatIsPlayer); // same as detecting enemies only this time items detect the player object

      //if player is detected...
      if(playerDetected==true)
      {
          Physics2D.IgnoreCollision(knight.GetComponent<Collider2D>(),GetComponent<Collider2D>());
        if(Input.GetKeyDown(KeyCode.E))
        {
          print("oof"); // testing
          PlayerStats.instance.GetGold(pickupQuantity);
          Destroy(gameObject); 
          
        }
      }
    }

    
    private void OnDrawGizmosSelected(){
      Gizmos.color=Color.blue;
      Gizmos.DrawWireCube(doorPos.position, new Vector3(width, height, 1));
    }
}

