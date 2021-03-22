using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput, verticalInput;
    public float speed = 10.0f;

    public float xRange = 15.0f;
    public Vector2 zRange = new Vector2(0.0f, 15.0f);

    public GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Movimiento del personaje
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.right);
        transform.Translate(verticalInput * speed * Time.deltaTime * Vector3.forward);

        if (transform.position.x < -xRange)
        {
            // Se sale a la izquierda de la pantalla
            transform.position = new Vector3(-xRange,
                                             transform.position.y,
                                             transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            // Se sale a la derecha de la pantalla
            transform.position = new Vector3(xRange,
                                             transform.position.y,
                                             transform.position.z);
        }
        if (transform.position.z > zRange.y)
        {
            // Se sale arriba de la pantalla
            transform.position = new Vector3(transform.position.x,
                                             transform.position.y,
                                             zRange.y);
        }
        if (transform.position.z < zRange.x)
        {
            // Se sale por abajo de la pantalla
            transform.position = new Vector3(transform.position.x,
                                             transform.position.y,
                                             zRange.x);
        }
        // Acciones del personaje
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Si entramos aquí, hay que lanzar un proyectil
            Instantiate(projectilePrefab,
                        transform.position,
                        projectilePrefab.transform.rotation);
        }
    }
}
