using UnityEngine;

public class EnemyScript : MonoBehaviour {
    public float moveSpd = 1.5f;

    private Transform _transform;
    private Rigidbody2D _rigidBody;
    private int _dir = -1;

    void Start() {
        this._transform = GetComponent<Transform>();
        this._rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update() {
        this._transform.Translate(this._dir * Time.deltaTime, 0, 0);

        IsHittedWall();
    }

    void IsHittedWall() {
        if (this._rigidBody.velocity.x <= 0) {
            this._dir *= -1;
            // ray dir change
        }
    }
}
