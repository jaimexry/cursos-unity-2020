using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundsX : MonoBehaviour
{
    private float leftLimit = -30.0f;           // Límite izquierdo de la pantalla
    private float bottomLimit = -5.0f;          // Límite inferior de la pantalla
    
    // Update is called once per frame
    void Update()
    {
        // Destroy dogs if x position less than left limit
        if (transform.position.x < leftLimit)
        {
            Destroy(gameObject);
        } 
        // Destroy balls if y position is less than bottomLimit
        if (transform.position.y < bottomLimit)
        {
            Debug.Log("GAME OVER!!!");
            Destroy(gameObject);
            Time.timeScale = 0.0f;                      // Detenemos el tiempo si perdemos
        }

    }
}
