using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePropeller : MonoBehaviour
{
   private float speed = 100000.0f;

    // Update is called once per frame
    void Update()
    {
       this.transform.Rotate(Vector3.forward * Time.deltaTime * speed); 
    }
}
