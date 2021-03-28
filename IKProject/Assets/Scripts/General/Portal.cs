using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{


    [SerializeField] int sceneToLoad=-1;
    public Animator transition;
    public Vector2 playerPosition;
    public Position playerMemory;

   

   public void OnTriggerEnter2D(Collider2D other){
       if(other.tag=="Player")
       {
           playerMemory.initialPosition= playerPosition;
           transition.SetTrigger("Start");
           SceneManager.LoadScene(sceneToLoad);
       }
   }
}
