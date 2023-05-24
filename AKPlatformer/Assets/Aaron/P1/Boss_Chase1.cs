using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class Boss_Chase1 : StateMachineBehaviour
{
    
    //creates a place to store the players transform information 
    Transform player;
    //creates a place to store the rigidbody
    Rigidbody2D rb;

    // create a place to store our bosses behavior
    BossBehavior1 bossBehavior;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //sets the reference for our players location
        player = GameObject.FindGameObjectWithTag("Player").transform;

        //set reference for my rigidbody
        rb = animator.GetComponent<Rigidbody2D>();

        //set and fill in the information we are looking for
        bossBehavior = animator.GetComponent<BossBehavior1>();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // finds the player as target and locks the boss on the y axis
        Vector2 target = new Vector2(player.position.x, rb.position.y);

        //send our boss to move towards its target
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, bossBehavior.speed * Time.deltaTime);

        //tell our boss to move its position
        rb.MovePosition(newPos);

        float distance = Vector2.Distance(player.position, rb.position);
        //Phase1
        if (distance < bossBehavior.attackRange && !bossBehavior.phase2 && !bossBehavior.phase3 && !bossBehavior.isDead)
        {
            animator.SetTrigger("MeleeAttack");

        }
        //phase2
        else if (distance < bossBehavior.attackRange && bossBehavior.phase2 && !bossBehavior.phase3 && !bossBehavior.isDead)
        {
            animator.SetTrigger("Phase2Attack");
        }
        //phase3
        else if (distance < bossBehavior.attackRange && !bossBehavior.phase2 && bossBehavior.phase3 && !bossBehavior.isDead)
        {
            animator.SetTrigger("Phase3Attack");
        }
        //Dead
        else if (bossBehavior.isDead)
        {
            animator.SetTrigger("Death");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

}
