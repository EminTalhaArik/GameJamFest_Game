using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class war : MonoBehaviour
{

    [Header("Guns")]
    public GameObject swordObject;
    public GameObject gunObject;

    public Transform bulletPos;

    public GameObject bulletObject;

    public float bulletForce = 100f;

    [Header("Components")]
    public BoxCollider2D warTrigger;

    //Components
    private Animator myAnimator;

    //Default Values
    private float defaultCooldownBack = 1f;
    private float cooldownBack;

    private float defaultGunCooldownBack = 1f;
    private float gunCooldownBack;

    private void Start()
    {
        ResetValues();
        ComponentDefine();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            gunObject.SetActive(false);
            swordObject.SetActive(true);
            warTrigger.enabled = true;
            myAnimator.SetTrigger("sword");
        }
        else
        {
            warTrigger.enabled = false;
            cooldownBack -= Time.deltaTime;
            if(cooldownBack <= 0)
            {
                swordObject.SetActive(false);
                cooldownBack = defaultCooldownBack;
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            swordObject.SetActive(false);
            gunObject.SetActive(true);

            GameObject spawnObject = Instantiate(bulletObject, bulletPos.position, Quaternion.identity);


            if (GetComponent<PlayerMovement>().isRight)
            {
                spawnObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletForce, 30f));
            }
            else if(!GetComponent<PlayerMovement>().isRight)
            {
                spawnObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-bulletForce, 30f));
            }
        }
        else
        {
            gunCooldownBack -= Time.deltaTime;
            if (gunCooldownBack <= 0)
            {
                gunObject.SetActive(false);
                gunCooldownBack = defaultGunCooldownBack;
            }
        }
    }

    private void ResetValues()
    {
        swordObject.SetActive(false);
        warTrigger.enabled = false;
        cooldownBack = defaultCooldownBack;
    }

    private void ComponentDefine()
    {
        myAnimator = GetComponent<Animator>();
    }

    //Enemy Health Control
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponentInParent<Enemy>().SetDamage(20);
        }
    }
}
