using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
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
    
    /// <summary>
    /// Inicia la partida cambiando el estado de juego a inGame
    /// </summary>
    /// <param name="difficulty">Número entero que indica la dificultad del juego</param>
    public void StartGame(int difficulty)
    {
        gameState = GameState.inGame;
        spawnRate /= difficulty;
        StartCoroutine(SpawnTarget());

        Score = 0; 
        UpdateScore(0);
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        titleScreen.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
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
    /// Actualiza el estado del juego a GameOver
    /// </summary>
    public void GameOver()
    {
        gameState = GameState.gameOver;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    /// <summary>
    /// Recarga la escena actual del videojuego
    /// </summary>
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
