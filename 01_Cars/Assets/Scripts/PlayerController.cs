using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // PROPIEDADES
    [Range(0, 20), SerializeField, Tooltip("Velocidad lineal máxima del coche")]
    private float speed = 10.0f;
    [Range(0, 90), SerializeField, Tooltip("Velocidad de giro máxima del coche")]
    private float turnSpeed = 45.0f;

    private float horizontalInput, verticalInput;
    
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        // S = s0 + V*t*(dirección)
        transform.Translate(speed * Time.deltaTime * Vector3.forward * verticalInput); //0,0,1
        transform.Rotate(turnSpeed * Time.deltaTime * Vector3.up * horizontalInput);
    }
}
