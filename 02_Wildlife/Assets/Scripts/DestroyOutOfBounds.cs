using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30.0f;
    private float lowerBound = -10.0f;
    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.z > topBound)
        {
            Destroy(this.gameObject);
        }

        if (this.transform.position.z < lowerBound)
        {
            Debug.Log("GAME OVER!!!!");
            Destroy(this.gameObject);
            Time.timeScale = 0;
        }
    }
}
