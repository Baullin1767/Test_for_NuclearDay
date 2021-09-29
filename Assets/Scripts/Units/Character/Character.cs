using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : Unit
{
    public bool canAttack = false;
    [SerializeField]
    GameObject attention;
    [SerializeField]
    GameObject gameOverUI;
    [SerializeField]
    GameController gameController;

    protected override void Start()
    {
        base.Start();
        attention.SetActive(false);
    }

    protected override void Update()
    {
        Walk();
    }
    public void Direction(int InputAxis) 
    {
        movement = InputAxis;
    }
    protected override void Walk()
    {
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

        if (Input.GetKeyDown(KeyCode.Mouse0) && canAttack)
        {
            Attack();
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(nameof(Attention));
            
        }
    }

    IEnumerator Attention()
    {
        attention.SetActive(true);
        yield return new WaitForSeconds(1f);
        attention.SetActive(false);
    }

    protected override void Attack()
    {
        if (!currentState.Equals("Attack"))
        {
            previousState = currentState;
        }
        SetUnitState("Attack");
    }

    public override void Death()
    {
        gameController.LoseGame();
        gameObject.SetActive(false);
    }
}
