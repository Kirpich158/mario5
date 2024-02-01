using UnityEngine;

public class PlayerScript : MonoBehaviour {
    public float speed;
    public float jumpMultiplier;
    public int maxJumpCount;
    public int lives;

    [SerializeField]
    private GameOverScript goScript;
    private int _jumpCount = 0;
    private Transform _transform;
    private Rigidbody2D _rigidBody;
    private bool _isGrounded = false;
    private float _rayLength = 0.6f;
    private LayerMask _groundLayer;

    void Start() {
        this._transform = GetComponent<Transform>();
        this._rigidBody = GetComponent<Rigidbody2D>();
        this._jumpCount = this.maxJumpCount;
        _groundLayer = LayerMask.GetMask("ground");
    }

    void Update() {
        this._Movement();

        // ==> GAME OVER LOGIC <==
        if (this.lives == 0) {
            Debug.Log("GameOver");
        }
    }

    private void _Movement() {
        // horizontal movement
        _transform.Translate(Input.GetAxis("Horizontal") * this.speed * Time.deltaTime, 0, 0);

        // jump
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && this._jumpCount > 0) {
            this._rigidBody.AddForce(_transform.up * this.jumpMultiplier, ForceMode2D.Impulse);
            this._isGrounded = false;
            this._jumpCount--;
        }

        // is able to jump check
        RaycastHit2D hit = Physics2D.Raycast(_transform.position, Vector2.down, this._rayLength, _groundLayer);
        if (hit && _rigidBody.velocity.y <= 0) {
            this._isGrounded = true;
            this._jumpCount = this.maxJumpCount;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            this.lives--;
            Debug.Log("enemy hitted");
        }
    }
}
