using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopHandler : MonoBehaviour
{

    public Text speedUpgradeCostText;
    public Button speedPurchaseButton;
    public Text jumpUpgradeCostText;
    public Button jumpPurchaseButton;
    public Text dashUpgradeCostText;
    public Button dashPurchaseButton;
    public int speedUpgradeCost = 10;
    public float speedIncreaseAmount = 2f;
    public int jumpUpgradeCost = 10;
    public float jumpIncreaseAmount = 2f;
    public int dashUpgradeCost = 10;
    public float dashIncreaseAmount = 2f;
    
    void Start()
    {
        //UpdateUI();
    }

    void UpdateUI()
    {
        speedUpgradeCostText.text = speedUpgradeCost.ToString() + "x Coins";
        speedPurchaseButton.interactable = PointsHandler.singleton.GetScore() >= speedUpgradeCost;

        jumpUpgradeCostText.text = jumpUpgradeCost.ToString() + "x Coins";
        jumpPurchaseButton.interactable = PointsHandler.singleton.GetScore() >= jumpUpgradeCost;

        dashUpgradeCostText.text = dashUpgradeCost.ToString() + "x Coins";
        dashPurchaseButton.interactable = PointsHandler.singleton.GetScore() >= dashUpgradeCost;
    }

    public void speedPurchaseUpgrade()
    {
        int currentPoints = PointsHandler.singleton.GetScore();

        if (currentPoints >= speedUpgradeCost)
        {
            PointsHandler.singleton.AddScore(-speedUpgradeCost); // Deduct points
            // Apply the upgrade (e.g., increase player speed)
            // You can customize this part based on your game's mechanics
            // For example, you might have a PlayerMovement script that handles speed.
            // PlayerMovement.singleton.IncreaseSpeed(speedIncrease);
            PlayerInputHandler playerInputHandler = FindObjectOfType<PlayerInputHandler>();
            if (playerInputHandler != null)
            {
                playerInputHandler.IncreasePlayerSpeed(5f); // Increase speed by 5
            }

            // Update the UI after the purchase
            //UpdateUI();
        }
    }

}
