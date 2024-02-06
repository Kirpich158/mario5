using System;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerScript : MonoBehaviour {
    public float speed;
    public float jumpMultiplier;
    public float enemyImpulseMultiplier;
    public int maxJumpCount;
    public int lives;
    public int score;
    public Rigidbody2D rigidBody;

    [SerializeField]
    private GameOverScript goScript;
    private int _jumpCount = 0;
    private bool _isGrounded = false;
    readonly float _rayLength = 0.6f;
    private LayerMask _groundLayer;
    private LayerMask _surpriseBoxLayer;

    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
        _jumpCount = maxJumpCount;
        _groundLayer = LayerMask.GetMask("ground");
        _surpriseBoxLayer = LayerMask.GetMask("surprise");
    }

    void Update() {
        // Movement();

        // ==> GAME OVER LOGIC <==
        if (lives == 0) {
            Debug.Log("GameOver");
        }

        // jumping
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && _jumpCount > 0) {
            rigidBody.AddForce(transform.up * jumpMultiplier, ForceMode2D.Impulse);
            _isGrounded = false;
            _jumpCount--;
        }
    }

    void FixedUpdate() {
        Movement();
    }

    private void Movement() {
        // horizontal movement
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0);

        // is able to jump on the ground check
        RaycastHit2D groundHitL = Physics2D.Raycast(new Vector2(transform.position.x - 0.5f, transform.position.y), Vector2.down, _rayLength, _groundLayer);
        RaycastHit2D groundHitR = Physics2D.Raycast(new Vector2(transform.position.x + 0.5f, transform.position.y), Vector2.down, _rayLength, _groundLayer);
        if ((groundHitL || groundHitR) && rigidBody.velocity.y <= 0) {
            _isGrounded = true;
            _jumpCount = maxJumpCount;
            Debug.DrawRay(new Vector2(transform.position.x + 0.5f, transform.position.y), Vector2.down, Color.green);
            Debug.DrawRay(new Vector2(transform.position.x - 0.5f, transform.position.y), Vector2.down, Color.green);
        }

        RaycastHit2D surpriseBoxHit = Physics2D.Raycast(transform.position, Vector2.up, _rayLength, _surpriseBoxLayer);
        if (surpriseBoxHit) {

        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            lives--;
        }
    }
}
