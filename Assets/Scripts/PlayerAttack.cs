using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject projectile_;
    EntityStats entity_stats;

    float cooldown_;
    bool can_attack = true;


    // Start is called before the first frame update
    void Start()
    {
        entity_stats = gameObject.GetComponent<EntityStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && can_attack)
        {
            GameObject projectile_instance = Instantiate(projectile_, transform.position, Quaternion.identity);

            projectile_instance.GetComponent<ProjectileDamage>().projectile_damage = entity_stats.attack_damage;

            Vector2 projectile_direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            projectile_direction.Normalize();
            projectile_instance.GetComponent<Rigidbody2D>().AddForce(projectile_direction * 10, ForceMode2D.Impulse);

            cooldown_ = 1;
            can_attack = false;
        }

        Cooldown();
    }
    void Cooldown()
    {
        
        if (cooldown_ <= 0 && !can_attack) 
        {
            can_attack = true;
        }
        else
        {
            cooldown_ -= Time.deltaTime * entity_stats.attack_speed;
        }
    }
}
