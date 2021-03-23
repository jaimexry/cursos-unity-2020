using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerControllerY : MonoBehaviour
{
    public float speed, rotateSpeed;

    private Rigidbody _rigidbody;

    private float verticalInput, horizontalInput;

    public bool usePhysicsEngine;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        
        MovePlayer();
        KeepPlayerInBounds();
    }

    private void MovePlayer()
    {
        if (usePhysicsEngine)
        {
            _rigidbody.AddForce(Vector3.forward * verticalInput * speed * Time.deltaTime, ForceMode.Force);
            _rigidbody.AddTorque(Vector3.up * horizontalInput * speed * Time.deltaTime, ForceMode.Force);
        }
        else
        {
            transform.Translate(verticalInput * Vector3.forward * Time.deltaTime * speed);
            transform.Rotate(horizontalInput * Vector3.up * Time.deltaTime * rotateSpeed);
        }
    }

    private void KeepPlayerInBounds()
    {
        if (Mathf.Abs(transform.position.x) >= 24 || Mathf.Abs(transform.position.z) >= 24)
        {
            _rigidbody.velocity = Vector3.zero;
            if (transform.position.x > 24)
            {
                transform.position = new Vector3(24, transform.position.y, transform.position.z);
            }
            if (transform.position.x < -24)
            {
                transform.position = new Vector3(-24, transform.position.y, transform.position.z);
            }
            if (transform.position.z > 24)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 24);
            }
            if (transform.position.z < -24)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -24);
            }
        }
    }
}
