using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer1 : MonoBehaviour
{
    PlayerManager1 playerManager;
    // Start is called before the first frame update
    void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager1>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerManager.TakeDamage();
        }
    }
}
