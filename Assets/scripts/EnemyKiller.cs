using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class EnemyKiller : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            PlayerScript playerScript = gameObject.GetComponent<PlayerScript>();
            playerScript.rigidBody.AddForce(transform.up * playerScript.enemyImpulseMultiplier, ForceMode2D.Impulse);
            playerScript.score += 50;
        }
    }
}
