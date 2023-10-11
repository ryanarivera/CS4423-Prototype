using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleTrigger : MonoBehaviour
{
    public string mainMenuSceneName = "MainMenu"; // Replace with the name of your main menu scene

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("obstacle")) // Replace "Obstacle" with the tag of your obstacles
        {
            // Load the main menu scene when the player hits an obstacle
            SceneManager.LoadScene(mainMenuSceneName);
        }
    }
}
