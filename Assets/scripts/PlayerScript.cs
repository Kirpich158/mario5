using System;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    public float speed;
    public float jumpMultiplier;
    public float enemyImpulseMultiplier;
    public int maxJumpCount;
    public int lives;
    public int score;

    [SerializeField]
    private GameOverScript goScript;
    private int _jumpCount = 0;
    private Transform _transform;
    private Rigidbody2D _rigidBody;
    private bool _isGrounded = false;
    readonly float _rayLength = 0.6f;
    private LayerMask _groundLayer;
    private LayerMask _enemyLayer;

    void Start() {
        _transform = GetComponent<Transform>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _jumpCount = maxJumpCount;
        _groundLayer = LayerMask.GetMask("ground");
        _enemyLayer = LayerMask.GetMask("enemy");
    }

    void Update() {
        Movement();

        // ==> GAME OVER LOGIC <==
        if (lives == 0) {
            Debug.Log("GameOver");
        }
    }

    private void Movement() {
        // horizontal movement
        _transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0);

        // jump
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && _jumpCount > 0) {
            _rigidBody.AddForce(_transform.up * jumpMultiplier, ForceMode2D.Impulse);
            _isGrounded = false;
            _jumpCount--;
        }

        // is able to jump on the ground check 
        RaycastHit2D groundHit = Physics2D.Raycast(_transform.position, Vector2.down, _rayLength, _groundLayer);
        if (groundHit && _rigidBody.velocity.y <= 0) {
            _isGrounded = true;
            _jumpCount = maxJumpCount;
        }

        // is jumped on enemy
        RaycastHit2D enemyHit = Physics2D.Raycast(_transform.position, Vector2.down, _rayLength, _enemyLayer);
        if (enemyHit) {
            _rigidBody.AddForce(_transform.up * enemyImpulseMultiplier, ForceMode2D.Impulse);
            score += 50;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            lives--;
            Debug.Log("enemy hitted");
        }
    }
}
