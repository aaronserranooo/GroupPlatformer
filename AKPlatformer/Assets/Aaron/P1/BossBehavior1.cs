using UnityEngine;

public class BossBehavior1 : MonoBehaviour
{
    //create a set a health variable for our boss
    public int bossHealth = 10;
    public float speed = 4.5f;
    public float attackRange = 2f;
    //create a series of bool to track the bosses phases
    public bool phase2 = false;
    public bool phase3 = false;
    public bool isDead = false;
    public Transform player;
    public bool isFlipped = false;
    PlayerManager1 playerManager;

    //create a shot location as a reference 
    public Transform shotLocation;
    public GameObject projectile;
    public GameObject projectile2;// drag our created prefab into this reference

    //create a timer system to shoot this projectile every 5 seconds with the
    //change this number
    public float timer;
    public int waitingTime;


    private void Start()
    {
        //Found and got our reference and set the information we are looking for
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager1>();
        //(position, rotation, scale)
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        //create a series of if else statements that will check to see
        //if the boss is below 7 and above 3, below 3 and above 1,
        //and is less than or equal to 0

        if (bossHealth < 7 && bossHealth > 3)
        {
            phase2 = true;
            speed = 2;
            attackRange = 6;
        }
        else if (bossHealth < 3 && bossHealth >= 1)
        {
            phase2 = false;
            phase3 = true;
            speed = 1;
            attackRange = 7;
        }
        else if (bossHealth <= 0)
        {
            phase3 = false;
            isDead = true;
        }

        timer += Time.deltaTime;
    }

    public void ProjectileShoot()
    {
        if (timer > waitingTime)
        {
            if (phase2)
            {
                //creates a new gameobject based off our prefab
                GameObject clone = Instantiate(projectile, shotLocation.position, Quaternion.identity);
                timer = 0;
            }
            else if (phase3)
            {
                GameObject clone = Instantiate(projectile2, shotLocation.position, Quaternion.identity);
                timer = 0;
            }

        }
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0, 180, 0);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0, 180, 0);
            isFlipped = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerManager.TakeDamage();
        }
    }
}
