using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//used from the inside of houses etc to transition back to the original scene
public class Portal : MonoBehaviour
{

    [SerializeField] int sceneToLoad=-1; //Editable scene to load
    public Animator transition; 
    public Vector2 playerPosition; //player position
    public Position playerMemory;  //var to store player position

   
    //Change Scene on collide
    public void OnTriggerEnter2D(Collider2D other)
    {
       if(other.tag=="Player")
       {
           playerMemory.initialPosition= playerPosition;
           transition.SetTrigger("Start");
           SceneManager.LoadScene(sceneToLoad);
       }
   }
}
