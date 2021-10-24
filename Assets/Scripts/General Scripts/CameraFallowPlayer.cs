using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFallowPlayer : MonoBehaviour
{
    //Player
    private GameObject player;

    //Fallow Obstacles
    [Header("Cameras Obstacles")]
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(player.transform.position.x,minX,maxX), Mathf.Clamp(player.transform.position.y, minY, maxY), transform.position.z);    
    }


}
