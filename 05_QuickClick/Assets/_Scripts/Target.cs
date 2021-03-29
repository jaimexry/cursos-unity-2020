using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{

    private Rigidbody _rigidbody;

    private float minForce = 15,
        maxForce = 17,
        maxTorque = 10,
        xRange = 4,
        ySpawnPos = -6;

    private GameManager gameManager;
    
    [Range(-100, 100)]
    public int pointsValue;

    public ParticleSystem explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(RandomForce(), ForceMode.Impulse);
        _rigidbody.AddTorque(RandomTorque(), RandomTorque(),
                             RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPosition();

        gameManager = FindObjectOfType<GameManager>();
    }

    /// <summary>
    /// Genera un Vector3 aleatorio en 3D
    /// </summary>
    /// <returns>Fuerza aleatoria hacia arriba</returns>
    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minForce, maxForce);
    }

    /// <summary>
    /// Genera un número Float aleatorio
    /// </summary>
    /// <returns>Valor aleatorio entre -maxTorque y maxTorque</returns>
    private float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    
    /// <summary>
    /// Genera una posición aleatoria
    /// </summary>
    /// <returns>Posición aleatoria en 3D, con la coordenada z = 0</returns>
    private Vector3 RandomSpawnPosition()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    private void OnMouseOver()
    {
        if (gameManager.gameState == GameManager.GameState.inGame)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointsValue);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KillZone"))
        {
            if (gameObject.CompareTag("Good"))
            {
                gameManager.GameOver();
            }
            Destroy(gameObject);
        }
    }
    
}
