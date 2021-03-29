using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailMovement : MonoBehaviour
{
    public float speed = 10;
    private Vector3 target;
    private GameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameState == GameManager.GameState.inGame)
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
            target.z = 0f;
            this.transform.position = Vector3.MoveTowards(transform.position, target, speed);
        }
    }
}
