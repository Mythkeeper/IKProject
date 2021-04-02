using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{   

    [SerializeField] int sceneToLoad=-1; // editable scene to load through editor
   
    //Function to load the game scene
    public void PlayGame()
    {
        
        SceneManager.LoadScene(sceneToLoad);
            
     }
    
    //Function to Quit the game
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
