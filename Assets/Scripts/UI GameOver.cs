using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Drag the score text object to this field in the Inspector

    void Start()
    {
        GameSession gameSession = FindObjectOfType<GameSession>();
        if (gameSession != null && scoreText != null)
        {
            int score = gameSession.GetScore();
            scoreText.text = "Score: " + score.ToString(); // Update the score text
        }
    }
}
