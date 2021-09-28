using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doctor : Unit
{
    [SerializeField]
    private Transform characters;

    public bool characterIsDying = false;
    protected override void Update()
    {
        Walk();
    }
    protected override void Walk()
    {
        movement = transform.position.x - characters.position.x;
        rb.velocity = new Vector2(movement * speed, rb.velocity.y);
        if (movement != 0 && characterIsDying)
        {
            SetUnitState("Walking");
            if (movement > 0)
            {
                transform.localScale = new Vector2(0.7f, 0.7f);
            }
            else
            {
                transform.localScale = new Vector2(-0.7f, 0.7f);
            }
        }
        else
        {
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
}
