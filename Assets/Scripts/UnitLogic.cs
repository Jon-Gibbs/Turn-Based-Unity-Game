using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int unitLevel;
    public int damage;
    public int maxHP;
    public int currentHP;
    public int healAmount;

    public bool takeDamage(int damage)
    {
       currentHP = currentHP - damage;
        return (currentHP > 0);
    }
    public void Heal()
    {
        currentHP += healAmount;
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
    }
}
   

