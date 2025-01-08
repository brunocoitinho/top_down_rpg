using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    //Stats

    EntityStats entity_stats;
    float move_speed;

    GameObject player_object;
    // Start is called before the first frame update
    void Start()
    {
        player_object = GameObject.FindGameObjectWithTag("Player");
        entity_stats = gameObject.GetComponent<EntityStats>();
        move_speed = entity_stats.base_speed;
    }

    void FixedUpdate()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player_object.transform.position, move_speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<EntityStats>().hp -= entity_stats.attack_damage;
            entity_stats.hp -= entity_stats.hp + 1;
        }
    }
}
