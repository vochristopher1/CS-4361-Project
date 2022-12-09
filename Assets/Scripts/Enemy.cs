using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private string currentState = "IdleState";
    private Transform target;
    public float chaseRange = 5;
    public float speed = 3;
    public float attackRange = 2;
    public int health;
    public int maxHealth;
    public Animator animator;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        health = maxHealth;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if (PlayerManager.gameOver)
        {
            animator.enabled = false;
            this.enabled = false;
        }

        if (currentState == "IdleState")
        {
            if (distance < chaseRange) 
                currentState = "ChaseState";
        }
        else if (currentState == "ChaseState")
        {
            animator.SetBool("Chase", true);
            animator.SetBool("attacking", false);

            if (distance < attackRange)
            {
                currentState = "AttackState";
            }

            if (target.position.x > transform.position.x)
            {
                transform.Translate(transform.right * speed * Time.deltaTime);
                transform.rotation = Quaternion.identity;
            }
            else
            {
                transform.Translate(-transform.right * speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
        else if (currentState == "AttackState")
        {
            animator.SetBool("attacking", true);

            if (distance > attackRange)
                currentState = "ChaseState";
        }
    }

    public void Kill() 
    {
        Destroy(gameObject);
    }
}
