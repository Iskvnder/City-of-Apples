using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public Text coreTimerText;
    public Text currentLevelText;
    public Text foodText;

    public EatablesGenerator eatablesGenerator;

    public LayerMask groundMask;
    public LayerMask wallMask;

    public Transform groundCheck;
    public Transform rightWallCheck;
    public Transform leftWallCheck;

    public GameObject intro;

    public bool grounded = false;
    public bool isTouchingWallRight = false;
    public bool isTouchingWallLeft = false;

    public int jumpsLeft;
    public int seconds;

    private Rigidbody2D rigidbodyPlayer;
    private SpriteRenderer spriteRenderer;

    private float timeRemaining = 0;

    private float groundRadius = 1f;
    private float wallRadius = 0.2f;

    private float jumpForce = 16f;
    private float speed = 8f;

    private int maxJumps = 1;


    private void Awake() {
        SaveData.LoadFile();
    }

    void Start() {
        rigidbodyPlayer = GetComponent<Rigidbody2D>();
        jumpsLeft = maxJumps;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        currentLevelText.text = "Level " + SaveData.currentLevel + "\n You have to help - " + SaveData.currentLevel * 2;
        timeRemaining = 15 + SaveData.currentLevel * 2 * 5;
        if (SaveData.starterHit == true) intro.SetActive(true);
    }

    void Update() {
        if (timeRemaining > 0) {
            timeRemaining -= Time.deltaTime;
            seconds = Mathf.FloorToInt(timeRemaining % 60);
            
            coreTimerText.text = seconds + "";

            if (seconds == 0) {
                SaveData.starterHit = false;
                SaveData.SaveFile();
                SceneManager.LoadScene("CoreAbdullaScene");
            }

            if (seconds % 5 == 0 && eatablesGenerator.currentActiveWindows < eatablesGenerator.maxActiveWindows) {
                eatablesGenerator.GenerateWindows();
            }
        }

        if (int.Parse(foodText.text) == SaveData.currentLevel * 2) {
            SaveData.currentLevel++;
            SaveData.starterHit = false;
            SaveData.SaveFile();
            SceneManager.LoadScene("CoreAbdullaScene");
        }

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundMask);

        if (Input.GetKeyDown(KeyCode.Space)) {
            
            if (grounded) {
                Jump();
                jumpsLeft = maxJumps;
            } else

            if (!grounded && jumpsLeft > 0) {
                Jump();
                jumpsLeft--;
            }
        }

        isTouchingWallRight = Physics2D.OverlapCircle(rightWallCheck.position, wallRadius, wallMask);
        isTouchingWallLeft = Physics2D.OverlapCircle(leftWallCheck.position, wallRadius, wallMask);
        
        if (isTouchingWallRight && !grounded) rigidbodyPlayer.velocity = new Vector2(0, rigidbodyPlayer.velocity.y); else
        if (isTouchingWallLeft && !grounded) rigidbodyPlayer.velocity = new Vector2(0, rigidbodyPlayer.velocity.y); else 
        Run();
        
    }


    private void Jump() {
        rigidbodyPlayer.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, jumpForce);
    }

    private void Run() {
        if (Input.GetAxis("Horizontal") < 0) spriteRenderer.flipX = true; else spriteRenderer.flipX = false;
        rigidbodyPlayer.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rigidbodyPlayer.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Food") {

            eatablesGenerator.activeWindows[int.Parse(collision.name)] = false;
            eatablesGenerator.aims.Remove(collision.gameObject);

            eatablesGenerator.currentActiveWindows--;
            Destroy(collision.gameObject);
        }
    }

}
