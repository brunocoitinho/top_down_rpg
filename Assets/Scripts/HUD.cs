using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Slider hp_bar;
    EntityStats player_stats;

    // Start is called before the first frame update
    void Start()
    {
        player_stats = GameObject.FindGameObjectWithTag("Player").GetComponent<EntityStats>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerHP();
    }

    void PlayerHP()
    {
        hp_bar.maxValue = player_stats.max_hp;
        hp_bar.value = player_stats.hp;
    }
}
