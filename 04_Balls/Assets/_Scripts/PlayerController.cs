using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public float moveForce;
    
    private GameObject focalPoint;

    public bool hasPowerUp;
    public float powerUpForce;
    public float powerUpTime;
    public GameObject[] powerUpIndicators;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        _rigidbody.AddForce(focalPoint.transform.forward * moveForce * forwardInput,
                            ForceMode.Force);
        foreach (GameObject indicator in powerUpIndicators)
        {
            indicator.transform.position = this.transform.position + 0.5f * Vector3.down;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            StartCoroutine(PowerUpCountdown());
            Destroy(other.gameObject);
        }

        if (other.name.CompareTo("KillZone") == 0)
        {
            SceneManager.LoadScene("Prototype 4");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody _enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - this.transform.position);
            _enemyRigidbody.AddForce(awayFromPlayer * powerUpForce, ForceMode.Impulse);
            
            Debug.Log("El jugador ha colisionado contra " + collision.gameObject+
                      " y tiene el power up a " + hasPowerUp);
        }
    }

    IEnumerator PowerUpCountdown()
    {
        foreach (GameObject indicator in powerUpIndicators)
        {
            indicator.SetActive(true);
            yield return new WaitForSeconds(powerUpTime / powerUpIndicators.Length);
            indicator.SetActive(false);
        }
        hasPowerUp = false;
    }
}
