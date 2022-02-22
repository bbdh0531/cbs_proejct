using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int cur_health;
    public int cur_armor;
    [SerializeField]int max_health;

    bool isDead;

    public bool p_isDead
    { 
        get
        {
            return isDead;
        }
    }

    public void Damage(int _damage)
    {
        if(cur_armor<0)
        {
            cur_health -= _damage;
            UIManager.instance.health.text = cur_health.ToString();
            isDead = true;
        }
        else
        {
            cur_armor -= _damage;
            UIManager.instance.armor.text = cur_armor.ToString();
        }
    }
}
