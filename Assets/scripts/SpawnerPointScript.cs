using UnityEngine;

public class SpawnerPointScript : MonoBehaviour
{
    public GameObject enemyPrefab;

    private bool isSpawned = false;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player") && !isSpawned) {
            Instantiate(enemyPrefab, transform.position, enemyPrefab.transform.rotation);
            isSpawned = true;
        }
    }
}
