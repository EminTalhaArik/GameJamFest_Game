using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //collision.gameObject.GetComponent<Rigidbody2D>().AddForce(collision.gameObject.transform.right * 400);
        }
        Destroy(this.gameObject);
    }
}
