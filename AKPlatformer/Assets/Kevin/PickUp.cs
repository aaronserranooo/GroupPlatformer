using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup5 : MonoBehaviour
{
    //Set a max health
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //creates a location and refrence for our player manager script
            playerManager manager = collision.GetComponent<playerManager>();


            if (manager)
            {
                bool pickedUp = manager.PickupItem(gameObject);

                if (pickedUp)
                {
                    Destroy(gameObject);

                }
            }
        }

    }


}
