using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{

    Transform player;
    Transform boss;
    Vector2 direction;
    Rigidbody2D rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        player = GameObject.FindGameObjectWithTag("Boss").transform;
        rb = GetComponent<Rigidbody2D>();
        if (boss.position.x >= player.position.x)
        {
            //left
            direction = new Vector2(-1, 0);
        }

        else
        {
            //right
            direction = new Vector2(1, 0);
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(direction * speed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Boss")
        {
            Destroy(gameObject);
        }
    }
}
