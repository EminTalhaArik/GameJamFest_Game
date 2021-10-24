using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    [Header("War Values")]
    //Cooldowns
    public float defaultCooldown = 3f;
    private float cooldown;

    //Default Values
    public bool isFight = false;
    
    //Objects
    private GameObject player;

    private void Start()
    {
        ResetValues();
        ObjectDefine();
    }

    private void FixedUpdate()
    {
        if (isFight)
        {
            cooldown -= Time.deltaTime;
            if(cooldown <= 0)
            {
                player.gameObject.GetComponent<Ayasofya>().SetDamage(10);
                cooldown = defaultCooldown;
            }
        }   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Base"))
        {
            isFight = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Base"))
        {
            isFight = false;
        }
    }

    private void ResetValues()
    {
        cooldown = defaultCooldown;
    }

    private void ObjectDefine()
    {
        player = GameObject.FindGameObjectWithTag("Base");
    }
}
