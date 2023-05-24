using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup1 : MonoBehaviour
{
    private void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Do stuff
            PlayerManager1 manager = collision.GetComponent<PlayerManager1>();

            if (manager)
            {                                       //left off here period 1
                bool pickedUp = manager.PickupItem(gameObject);
                if (pickedUp)
                {
                    Destroy(gameObject);
                }
            }
            
            
        }
    }
}
