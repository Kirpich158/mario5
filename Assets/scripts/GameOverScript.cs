using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {
    public float maxTimerVal;

    private float _gameOverTimer;
    private float _enemyTimer;
    private GameObject _enemyRef;

    void Start() {
        _gameOverTimer = -1;
        _enemyTimer = -1;
    }

    void Update() {
        // game over restart
        if (_gameOverTimer > 0) {
            _gameOverTimer -= Time.deltaTime;
        } else if (_gameOverTimer <= 0 && _gameOverTimer != -1) {
            _gameOverTimer = -1;
            RestartTheLevel();
        }

        // enemy despawn timer
        if (_enemyTimer > 0) {
            _enemyTimer -= Time.deltaTime;
        }
        else if (_enemyTimer <= 0 && _enemyTimer != -1) {
            _enemyTimer = -1;
            Destroy(_enemyRef);
            _enemyRef = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D outsider) {
        if (outsider.CompareTag("Player")) {
            _gameOverTimer = maxTimerVal;
        }

        if (outsider.CompareTag("Enemy")) {
            _enemyRef = outsider.gameObject;
            _enemyTimer = maxTimerVal;
        }
    }

    private void RestartTheLevel() {
        Scene currentLvl = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentLvl.name);
    }
}
