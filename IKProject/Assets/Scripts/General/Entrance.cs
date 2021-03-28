using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Entrance : MonoBehaviour
{
    [SerializeField] int sceneToLoad=-1;

    private bool playerDetected;
    public Transform doorPos;
    public float width;
    public float height;
    public LayerMask whatIsPlayer;
      public Animator transition;
    public Vector2 playerPosition;
    public Position playerMemory;

    // Update is called once per frame
   private void Update()
    {
      playerDetected=Physics2D.OverlapBox(doorPos.position, new Vector2(width,height), 0 , whatIsPlayer);

      if(playerDetected==true){
        if(Input.GetKeyDown(KeyCode.X)){
          print("oof"); // testing
          playerMemory.initialPosition= playerPosition;
           transition.SetTrigger("Start");
           SceneManager.LoadScene(sceneToLoad);
        }
      }
    }
    private void OnDrawGizmosSelected(){
      Gizmos.color=Color.blue;
      Gizmos.DrawWireCube(doorPos.position, new Vector3(width, height, 1));
    }
}
