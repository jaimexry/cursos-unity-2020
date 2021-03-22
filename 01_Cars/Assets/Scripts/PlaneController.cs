using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    [Range(0, 20), SerializeField, Tooltip("Esta es la velocidad lineal del avión")]
    private float speed = 5.0f;
    [Range(0, 20), SerializeField, Tooltip("Esta es la velocidad máxima de rotación del avión")]
    public float turnSpeed = 5.0f;
    [Range(0, 20), SerializeField, Tooltip("Esta es la velocidad máxima de ascensión del avión")]
    public float ascendSpeed = 5.0f;

    private float horizontalInput, verticalInput;

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
        transform.Rotate(ascendSpeed * Time.deltaTime * Vector3.right * verticalInput);
        transform.Rotate(turnSpeed * Time.deltaTime * Vector3.back * horizontalInput);
        
    }
}
