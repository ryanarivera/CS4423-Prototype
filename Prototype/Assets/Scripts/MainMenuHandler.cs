using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    
    public void PlayGame(){
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame(){
        Debug.Log("Quit");
        Application.Quit(); //does not work in the editor
    }

}
