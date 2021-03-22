using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private const string SPEED_MULTIPLIER = "Speed_Multiplier";
    private const string JUMP_TRIGGER = "Jump_trig";
    private const string SPEED_F = "Speed_f";
    private const string DEATH_TYPE_INT = "DeathType_int";
    private const string DEATH_B = "Death_b";

    private Rigidbody playerRb;
    public float jumpForce = 10.0f;
    public float gravityMultiplier;
    private bool isOnTheGround = true;
    
    private bool _gameOver = false;
    public bool GameOver { get => _gameOver; }
    private Animator _animator;
    private float speedMultiplier = 1.0f;
    public ParticleSystem _explosion;
    public ParticleSystem _trail;

    public AudioClip jumpSound, crashSound;

    private AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity = gravityMultiplier * new Vector3(0, 9.81f, 0);
        _animator = GetComponent<Animator>();
        _animator.SetFloat(SPEED_F, 1);
    }

    // Update is called once per frame
    void Update()
    {
        speedMultiplier += Time.deltaTime / 10;
        _animator.SetFloat(SPEED_MULTIPLIER, speedMultiplier);
        if (isOnTheGround && !_gameOver && Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnTheGround = false;
            _trail.Stop();
            _animator.SetTrigger(JUMP_TRIGGER);
            _audioSource.PlayOneShot(jumpSound, 0.5f);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            if (!_gameOver)
            {
                isOnTheGround = true;
                _trail.Play();
            }
        }

        if (other.gameObject.CompareTag("Obstacle"))
        {
            _gameOver = true;
            Debug.Log("GAME OVER!!!!");
            _explosion.Play();
            _trail.Stop();
            _animator.SetInteger(DEATH_TYPE_INT, Random.Range(1, 3));
            _animator.SetBool(DEATH_B, true);
            _audioSource.PlayOneShot(crashSound, 1);
            Invoke("RestartGame", 1.0f);
        }
    }

    void RestartGame()
    {
        speedMultiplier = 1.0f;
        SceneManager.LoadSceneAsync("Prototype 3", LoadSceneMode.Single);
    }
}
