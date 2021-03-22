using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardX : MonoBehaviour
{
    [SerializeField, Range(0.0f, 40.0f), Tooltip("Velocidad del objeto")]
    private float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);      // Ecuación de movimiento del objeto
    }
}
