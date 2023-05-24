using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ProjectileBehavior1 : MonoBehaviour
{
    Transform player;
    Transform boss;
    Vector2 direction;
    Rigidbody2D rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        
        if (boss.position.x >= player.position.x)
        {
            direction = new Vector2(-1, 0);
        }
        else
        {
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
