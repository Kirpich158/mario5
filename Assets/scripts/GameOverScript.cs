using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {
    public float maxTimerVal;

    private float _timer;
    private BoxCollider2D _triggerCollider;

    public object Debug { get; internal set; }

    void Start() {
        _triggerCollider = GetComponent<BoxCollider2D>();
        _timer = -1;
    }

    void Update() {
        if (_timer > 0) {
            _timer -= Time.deltaTime;
        } else if (_timer <= 0 && _timer != -1) {
            _timer = -1;
            RestartTheLevel();
        }
    }

    private void OnTriggerEnter2D(Collider2D outsider) {
        if (outsider.CompareTag("Player")) {
            _timer = maxTimerVal;
        }
    }

    private void RestartTheLevel() {
        Scene currentLvl = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentLvl.name);
    }
}
