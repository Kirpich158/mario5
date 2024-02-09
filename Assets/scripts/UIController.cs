using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI scorePts;
    public TextMeshProUGUI lives;
    public PlayerScript player;

    void Update()
    {
        scorePts.text = "Score: " + player.Score.ToString();
        lives.text = "Lives: " + player.lives.ToString();
    }
}
