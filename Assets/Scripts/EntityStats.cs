using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStats : MonoBehaviour
{
    //Stats
    public float hp;
    public float max_hp;
    public float base_speed = 1.2f;
    public float attack_damage;
    public float attack_speed;

    private void Start()
    {
        hp = max_hp;
    }

    private void Update()
    {
        Death();
    }

    private void Death()
    {
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
