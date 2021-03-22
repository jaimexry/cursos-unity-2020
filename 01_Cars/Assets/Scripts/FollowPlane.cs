using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlane : MonoBehaviour
{
    public GameObject plane;

    private  Vector3 previousPosition = Vector3.zero;

    private float distance = 20.0f;
    // Update is called once per frame
    void Update()
    {
        Vector3 offset = plane.transform.position - previousPosition;
        if (offset.magnitude < 0.5f)
        {
            return;
        }
        offset.Normalize();
        
        this.transform.position = plane.transform.position - offset * distance;
        transform.LookAt(plane.transform.position);
        previousPosition = plane.transform.position;
    }
}
