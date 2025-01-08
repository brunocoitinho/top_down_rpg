using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Stats
    EntityStats entity_stats;

    float base_speed;
    // Start is called before the first frame update
    void Start()
    {
        entity_stats = gameObject.GetComponent<EntityStats>();
        base_speed = entity_stats.base_speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        WasdMove();
    }

    void WasdMove()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(horizontal, vertical);
        movement.Normalize();
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(movement.x * base_speed * 100 * Time.deltaTime, movement.y * base_speed * 100 * Time.deltaTime));

    }
}
