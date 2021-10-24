using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [Header("Object")]
    public GameObject[] enemies;
    public Transform[] spawnPositions;

    [Header("Values")]
    private float cooldown;

    public int maxEnemyCount = 5;
    private int enemyCount = 0;

    private float waveCooldown;
    public float defaultWaveCooldown = 4f;
    private int activeWaveCount = 1;
    private void Start()
    {
        ResetValues();
    }

    private void FixedUpdate()
    {
        if(enemyCount < maxEnemyCount)
        {
            cooldown -= Time.fixedDeltaTime;

            if (cooldown <= 0)
            {
                Vector2 selectedPos = spawnPositions[Random.Range(0, spawnPositions.Length)].position;
                GameObject selectedObject = enemies[Random.Range(0, enemies.Length)];

                GameObject spawnObject = Instantiate(selectedObject, selectedPos, Quaternion.identity);
                cooldown = Random.Range(2,6);
                enemyCount++;
            }
        }
        else
        {
            waveCooldown -= Time.deltaTime;
            
            if(waveCooldown <= 0)
            {
                maxEnemyCount += Random.Range(3,10);
                activeWaveCount++;
                GameObject.FindGameObjectWithTag("WaveController").GetComponent<TextMeshProUGUI>().text = "Wave : " + activeWaveCount;
                print("Wave deðiþti babuþ");
            }
        }
    }
     
    private void GroupSpawn()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            Vector2 selectedPos = spawnPositions[Random.Range(0, spawnPositions.Length)].position;
            GameObject selectedObject = enemies[Random.Range(0, enemies.Length)];

            GameObject spawnObject = Instantiate(selectedObject, selectedPos, Quaternion.identity);
        }
    }

    private void ResetValues()
    {
        cooldown = Random.Range(2, 6);
        waveCooldown = defaultWaveCooldown;
    }
}
