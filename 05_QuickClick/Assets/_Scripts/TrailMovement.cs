using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailMovement : MonoBehaviour
{
    private GameManager gameManager;
    public Camera _camera;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameState == GameManager.GameState.inGame)
        {
            Vector3 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
            mousePos = new Vector3(mousePos.x, mousePos.y);
            this.transform.position = mousePos;
        }
    }
}
