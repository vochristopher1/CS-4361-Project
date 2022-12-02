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

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        health = maxHealth;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if (currentState == "IdleState")
        {
            if (distance < chaseRange) 
                currentState = "ChaseState";
        }
        else if (currentState == "ChaseState")
        {
            if (target.position.x > transform.position.x)
            {
                transform.Translate(transform.right * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(-transform.right * speed * Time.deltaTime);
            }
        }
        else if (currentState == "AttackState")
        {
            if (distance > attackRange)
                currentState = "ChaseState";
        }
    }

/*
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health < 0)
        {
            Die();
        }
    }
*/
    public void Kill() 
    {
        Destroy(gameObject);
    }
}
