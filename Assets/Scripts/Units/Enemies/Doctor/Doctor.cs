using Spine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doctor : Unit
{
    [SerializeField]
    Transform character;
    [SerializeField]
    float distant;

    public bool characterIsDying = false;
    

    protected override void Update()
    {
        Walk();
        if (EnemyHealthBar.fill < 0.5f)
        {
            characterIsDying = true;
        }
    }
    protected override void Walk()
    {
        
        if (characterIsDying && Vector2.Distance(transform.position, character.position) >= distant)
        {
            SetUnitState("Walking");
            transform.position = Vector2.MoveTowards(transform.position, character.position, speed * Time.deltaTime);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
            AddAnimation(0, idle, false, 1f);
            if (!currentState.Equals("Attack"))
            {
                 SetUnitState("Idle");
            }
        }
        
    }
    protected override void Attack()
    {
        if (!currentState.Equals("Attack"))
        {
            previousState = currentState;
        }
        SetUnitState("Attack");
    }

    public void AttackCharacter() 
    {
        Attack();
    }

    protected override void Death()
    {
        if (HealthBar.fill <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
