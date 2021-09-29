using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggessiveZone : MonoBehaviour
{
    [SerializeField]
    float timeBtwAttack, startTimeBtwAttack;
    [SerializeField]
    Doctor doctor;
    [SerializeField]
    HealthBar healthBar;

    bool triggered = false;

    void Update()
    {
        if (triggered)
        {
            Attack();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            triggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            triggered = false;
        }
    }

    private void Attack()
    {
        if (timeBtwAttack <= 0)
        {
            doctor.AttackCharacter();
            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

}
