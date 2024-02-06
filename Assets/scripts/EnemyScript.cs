using UnityEngine;

public class EnemyScript : MonoBehaviour {
    public float moveSpd = 1.5f;

    private Transform _transform;
    private Rigidbody2D _rigidBody;
    private int _dir = -1;

    void Start() {
        _transform = GetComponent<Transform>();
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update() {
        _transform.Translate(_dir * Time.deltaTime, 0, 0);

        // IsHittedWall();
    }

    void IsHittedWall() {
        if (_rigidBody.velocity.x <= 0) {
            _dir *= -1;
            // ray dir change
        }
    }
}
