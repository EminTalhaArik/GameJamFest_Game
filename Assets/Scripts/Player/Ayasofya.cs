using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ayasofya : MonoBehaviour
{

    //Default Values
    private float health = 100f;

    public void SetDamage(int damage)
    {
        health -= damage;
        HealthControl();
        GameObject.FindGameObjectWithTag("SliderController").GetComponent<SliderController>().SetSliderValue(health);
    }

    private void HealthControl()
    {
        if(health <= 0)
        {
            print("Ayasofyay� koruyamad�k");
            Camera.main.gameObject.GetComponent<MenuManafer>().EndGame();
        }
        else
        {
            print("Ayasofyan�n can� : " + health);
        }
    }
}
