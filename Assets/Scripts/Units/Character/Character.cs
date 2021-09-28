using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Unit
{
    protected override void Update()
    {
        Walk();
    }
    protected override void Walk()
    {
        movement = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movement * speed, rb.velocity.y);
        if (movement != 0)
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

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
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
}
