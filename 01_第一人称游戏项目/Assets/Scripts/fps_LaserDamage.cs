using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fps_LaserDamage : MonoBehaviour {


    public int damage = 30;
    public float damageDelay = 1;

    private float lastDamageTime = 0;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player && Time.time > lastDamageTime + damageDelay)
        {
            player.GetComponent<fps_PlayerHealth>().TakeDamage(damage);
            lastDamageTime = Time.time;
        }
    }
}
