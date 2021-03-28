using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{   



   
    [SerializeField] int sceneToLoad=-1;
   
    public void PlayGame(){
        
    
            SceneManager.LoadScene(sceneToLoad);
            
        }
    
    public void QuitGame(){
        Debug.Log("Quit");
        Application.Quit();
    }
}
