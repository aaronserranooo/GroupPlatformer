using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject myPlayer;
   public int currentHealth;
    public int maxHealth =3;

    PlayerMovement playerMovement;
    public int coinCount;
    
    //Start is called before the first frame update
    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        currentHealth = maxHealth;
    }

    public bool PickupItem(GameObject obj)
    {
        switch (obj.tag)
        {
            case "Currency":
        coinCount++;
                return true;
            case "Speed+":
                //playerMovement.SpeedPowerUp();
                return true;
            default:
                Debug.Log("Item tag or reference not set.");
                return false;

        }
    }
    public void TakeDamage()
    {
        currentHealth -= 1;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spikes"))
        {
            Destroy(myPlayer);
        }
    }
}
