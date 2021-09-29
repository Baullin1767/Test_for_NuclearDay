using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    Image bar;
    [SerializeField]
    Unit unit;

    public float fill;

    void Start()
    {
        fill = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        bar.fillAmount = fill;
    }

    public void Damage()
    {
        fill -= 0.125f;
    }

    public void Healing() 
    {
        fill += Time.deltaTime * 0.05f;
    }

    public void Death() 
    {
        unit.Death();
    }

}
