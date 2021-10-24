using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBallMachine : MonoBehaviour
{
    [Header("Default Values")]
    private float cooldown;
    public float bigBulletForce = 100f;

    [Header("Objects And Transforms")]
    public GameObject bigBulletPrefab;
    public Transform bigBulletSpawnTransform;

    private void Start()
    {
        ResetValues();
    }

    private void FixedUpdate()
    {
        cooldown -= Time.fixedDeltaTime;

        if(cooldown <= 0)
        {
            GameObject spawnObject = Instantiate(bigBulletPrefab, bigBulletSpawnTransform.position, Quaternion.identity);
            spawnObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(bigBulletForce, 10f));
            cooldown = Random.Range(8,15);
        }
    }

    private void ResetValues()
    {
        cooldown = Random.Range(8, 15);
    }

}
