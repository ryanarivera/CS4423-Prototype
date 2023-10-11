using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointIncrease : MonoBehaviour
{
    private gameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<gameManager>();
    }

    private void OnDestroy()
    {
        if (gameManager != null)
        {
            gameManager.IncrementScore();
        }
    }
}
