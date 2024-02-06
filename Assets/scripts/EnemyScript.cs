using UnityEngine;

public class EnemyScript : MonoBehaviour {
    public float moveSpd = 1.5f;

    private Rigidbody2D _rigidBody;
    private int _dir = -1;
    private LayerMask _groundLayer;
    private Vector2 _rayDir;

    void Start() {
        _rigidBody = GetComponent<Rigidbody2D>();
        _groundLayer = LayerMask.GetMask("ground");
        _rayDir = Vector2.left;
    }

    void Update() {
        transform.Translate(_dir * Time.deltaTime, 0, 0);

        IsHittedWall();
    }

    void IsHittedWall() {
        RaycastHit2D wallHit = Physics2D.Raycast(transform.position, _rayDir, 0.6f, _groundLayer);
        if (wallHit && _rigidBody.velocity.x <= 0) {
            _dir *= -1;
            _rayDir *= -1;
        }
    }
}
