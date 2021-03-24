using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailMovement : MonoBehaviour
{
    public float speed = 10;
    private Vector3 target;

    void Start()
    {
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = 0f;
        this.transform.position = Vector3.MoveTowards(transform.position, target, speed);
    }
}
