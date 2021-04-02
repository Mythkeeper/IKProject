using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistroyableObject : CharacterStats
{   

    public GameObject drop;
   public override void Die()
   {
       Debug.Log("Overwritten");
       Instantiate(drop,transform.position,Quaternion.identity);
       Destroy(gameObject); 
   }
}
