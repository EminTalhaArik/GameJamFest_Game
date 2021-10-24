using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Default Values
    private float health = 100f;
    
    //AI
    private GameObject player;


    [Header("Enemy AI")]
    public float enemySpeed = 1f;

    //Component Define
    private Animator myAnimator;

    //Ground Checker
    public Transform groundCheckTransform;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;

    private bool isGround = false;

    private void Start()
    {
        ObjectDefinition();
        ComponentDefinition();
        enemySpeed = Random.Range(0.2f, 0.7f);
    }

    private void FixedUpdate()
    {
        GroundChecker();
        EnemyMove();
    }

    private void EnemyMove()
    {
        if(Vector2.Distance(this.transform.position,player.transform.position) < 50 && isGround)
        {
            this.transform.position = Vector2.Lerp(this.transform.position, player.transform.position, enemySpeed * Time.fixedDeltaTime);

            myAnimator.SetFloat("speed", 1f);

            if(transform.position.x > player.transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else
        {
            myAnimator.SetFloat("speed", 0);
        }
    }

    //Ground Checker
    public void GroundChecker()
    {
        if (Physics2D.OverlapCircle(groundCheckTransform.position, groundCheckRadius, groundCheckLayer))
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }
    }

    //Health Controller
    public void SetDamage(float damage)
    {
        health -= damage;
        HealthControl();
    }

    private void HealthControl()
    {
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void ObjectDefinition()
    {
        player = GameObject.FindGameObjectWithTag("Base");
    }

    private void ComponentDefinition()
    {
        myAnimator = transform.Find("Enemy").gameObject.GetComponent<Animator>();
    }

}
