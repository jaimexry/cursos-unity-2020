using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;            // Límite de Spawn por la izquierda en X
    private float spawnLimitXRight = 7;             // Límite de Spawn por la derecha en X
    private float spawnPosY = 30;                   // Lugar de Spawn por arriba en Y

    private float spawnTime = 5.0f;                 // Tiempo entre el Spawn de un enemigo y otro                 
    private float spawnCounter;                     // Contador del tiempo de Spawn

    // Start is called before the first frame update
    private void Update()
    {
        spawnCounter += Time.deltaTime;             // Aumentamos el valor del contador de Spawn
        if (spawnCounter >= spawnTime)  
        {
            Debug.LogFormat("Se ha Spawneado un objeto en {0} segundos", spawnTime);
            
            SpawnRandomBall();                      // Spawneamos un enemigo, en este caso una bola
            spawnCounter = 0.0f;                    // Reiniciamos el contador
            spawnTime = Random.Range(2, 5);         // Hacemos que el próximo Spawn sea aleatorio
        }
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        float spawnPosX = Random.Range(spawnLimitXLeft, spawnLimitXRight);      // Aleatorizamos el Spawn en X
        Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, 0);              // Vector3 del punto de Spawn final

        int ballIndex = Random.Range(0, ballPrefabs.Length);                    // Aleatorizamos el índice del objeto a Spawnear
        Instantiate(ballPrefabs[ballIndex],                                     // Instanciamos el objeto aleatorio en  
            spawnPos,                                                           // una posición aleatoria con su rotación
            ballPrefabs[ballIndex].transform.rotation);       
    }

}
