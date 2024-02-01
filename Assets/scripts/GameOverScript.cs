using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {
    public float maxTimerVal;

    private float _timer;
    private BoxCollider2D _triggerCollider;

    public object Debug { get; internal set; }

    void Start() {
        this._triggerCollider = GetComponent<BoxCollider2D>();
        this._timer = -1;
    }

    void Update() {
        if (this._timer > 0) {
            this._timer -= Time.deltaTime;
        } else if (this._timer <= 0 && this._timer != -1) {
            this._timer = -1;
            this.RestartTheLevel();
        }
    }

    private void OnTriggerEnter2D(Collider2D outsider) {
        if (outsider.CompareTag("Player")) {
            this._timer = this.maxTimerVal;
        }
    }

    private void RestartTheLevel() {
        Scene currentLvl = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentLvl.name);
    }
}
