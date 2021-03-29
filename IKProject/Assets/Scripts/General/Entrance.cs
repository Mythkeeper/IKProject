using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Entrance : MonoBehaviour
{
    [SerializeField] int sceneToLoad=-1; //To be able to choose which scene to load
    private bool playerDetected; //detect anything on player layer
    public Transform doorPos; // transform to detect player
    public float width; //editable width
    public float height; //editable height
    public LayerMask whatIsPlayer; //layer mask for player object
    public Animator transition; //transition animator
    public Vector2 playerPosition; //player position 
    public Position playerMemory; //Var to save player position

    // Update is called once per frame
   private void Update()
    {
      playerDetected=Physics2D.OverlapBox(doorPos.position, new Vector2(width,height), 0 , whatIsPlayer); //check for player

      if(playerDetected==true)
      {
        if(Input.GetKeyDown(KeyCode.X))
        {
          print("oof"); // testing
          playerMemory.initialPosition= playerPosition; //player position
          transition.SetTrigger("Start"); // transition animation trigger
          SceneManager.LoadScene(sceneToLoad); // load scene , choose which through unity
        }
      }
    }

    
    private void OnDrawGizmosSelected(){
      Gizmos.color=Color.blue;
      Gizmos.DrawWireCube(doorPos.position, new Vector3(width, height, 1));
    }
}
