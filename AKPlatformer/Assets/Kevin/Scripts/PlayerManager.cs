using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{
    //set a max health
    public int maxHealth;
    public int currentHealth;
    private MovementFr movementfr;
    public int coinCount;

    void Start()
    {

    }
    private void Update()
    {
        if (currentHealth <= 0)
        {
            PauseGame();
        }
    }
    public bool PickupItem(GameObject obj)
    {
        switch (obj.tag)
        {
            case "Currency":
                coinCount++;
                Debug.Log("You've Picked Up A Coin!");
                return true;
            case "Speed+":
                // call function here
                return true;
            default:
                Debug.Log("Item tag or refrence not set.");
                return false;
        }
    }

    public void TakeDamage()
    {
        currentHealth -= 1;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

}
