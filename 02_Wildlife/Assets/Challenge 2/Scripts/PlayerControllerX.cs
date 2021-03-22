using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    [SerializeField, Range(0.5f, 1.0f), Tooltip("Tiempo que pasa entre poder disparar una bala y otra")]
    private float recoilTime = 1.0f;
    private float recoilCounter = 0.0f;         // Contador de tiempo para disparar una bala
    // Update is called once per frame
    void Update()
    {
        recoilCounter += Time.deltaTime;                // Actualizamos el contador de recoil
        if (recoilCounter >= recoilTime && Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);       // Instanciamos una bala
            recoilCounter = 0f;                                                             // Reiniciamos el contador
        }
    }
}
