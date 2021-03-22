using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    private int animalIndex;

    private float spawnRangeX = 15.0f;
    private float spawnPosZ = 29.5f;
    
    [SerializeField, Range(2, 5), Tooltip("El Delay desde que empieza el juego hasta que se empiezan a generar animales")]
    private float startDelay = 2.0f;
    [SerializeField, Range(0.1f, 3), Tooltip("El tiempo que tarda en salir el próximo animal")]
    private float spawnInterval = 1.5f;
    private void Start()
    {
        spawnPosZ = transform.position.z;
        InvokeRepeating("SpawnRandomAnimal", 
                startDelay, 
            spawnInterval);
    }

    private void SpawnRandomAnimal()
    {
        float xRange = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPos = new Vector3(xRange, 0, spawnPosZ);
            
        animalIndex = Random.Range(0, enemies.Length);
        Instantiate(enemies[animalIndex], 
            spawnPos, 
            enemies[animalIndex].transform.rotation);
    }
}
