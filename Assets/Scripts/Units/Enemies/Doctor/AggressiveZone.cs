using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggressiveZone : MonoBehaviour
{
    [SerializeField]
    Doctor doctor;
    private void OnTriggerStay2D(Collider2D collision)
    {

        Character character = collision.GetComponent<Character>();
        if (character)
        {
            doctor.AttackCharacter();
        }
    }
}
