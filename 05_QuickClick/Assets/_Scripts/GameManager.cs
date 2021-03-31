using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    private const string MAX_SCORE = "MAX_SCORE";
    public enum GameState
    {
        loading,
        inGame,
        gameOver
    }

    public GameState gameState;
    

    public List<GameObject> targetPrefabs;

    private float spawnRate = 1.0f;

    public GameObject titleScreen;
    public Button restartButton;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    private int score;

    private int numberOfLives = 4;
    public List<GameObject> lives;

    private int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = Mathf.Clamp(value, 0, 9999);
        }
    }

    void Start()
    {
        ShowMaxScore();
    }

    /// <summary>
    /// Inicia la partida cambiando el estado de juego a inGame
    /// </summary>
    /// <param name="difficulty">Número entero que indica la dificultad del juego</param>
    public void StartGame(int difficulty)
    {
        gameState = GameState.inGame;
        spawnRate /= difficulty;
        numberOfLives -= difficulty;

        for (int i = 0; i < numberOfLives; i++)
        {
            lives[i].SetActive(true);
        }
        
        StartCoroutine(SpawnTarget());

        Score = 0; 
        UpdateScore(0);
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        titleScreen.gameObject.SetActive(false);
    }

    /// <summary>
    /// Crea objetos cada cierto tiempo en el escenario
    /// </summary>
    /// <returns>Cada valor de spawnRate crea nuevos objetos en el escenario</returns>
    IEnumerator SpawnTarget()
    {
        while (gameState == GameState.inGame)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targetPrefabs.Count);
            Instantiate(targetPrefabs[index]);
        }
    }
    
    /// <summary>
    /// Actualiza la puntuación y lo muestra por pantalla
    /// </summary>
    /// <param name="scoreToAdd">Número de puntos a añadir a la puntuación global</param>
    public void UpdateScore(int scoreToAdd)
    {
        Score += scoreToAdd;
        scoreText.text = "Puntuacion: " + Score;
    }

    /// <summary>
    /// Muestra la máxima puntuación conseguida por el usuario
    /// </summary>
    public void ShowMaxScore()
    {
        int maxScore = PlayerPrefs.GetInt(MAX_SCORE, 0);
        scoreText.text = "Puntuacion Maxima: \n" + maxScore;
    }

    /// <summary>
    /// Actualiza la puntuación máxima del usuario
    /// </summary>
    private void SetMaxScore()
    {
        int maxScore = PlayerPrefs.GetInt(MAX_SCORE, 0);
        if (score > maxScore)
        {
            PlayerPrefs.SetInt(MAX_SCORE, score);
        }
    }
    
    /// <summary>
    /// Actualiza el estado del juego a GameOver
    /// </summary>
    public void GameOver()
    {
        numberOfLives--;
        if (numberOfLives >= 0)
        {
            Image heartImage = lives[numberOfLives].GetComponent<Image>();
            var tempColor = heartImage.color;
            tempColor.a = 0.3f;
            heartImage.color = tempColor;
        }
        
        if (numberOfLives <= 0)
        {
            SetMaxScore();
            gameState = GameState.gameOver;
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// Recarga la escena actual del videojuego
    /// </summary>
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
