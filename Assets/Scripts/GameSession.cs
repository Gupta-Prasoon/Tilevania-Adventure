using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI; // Include this namespace for accessing UI components

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Image coinImage;

    [SerializeField] int score = 0;

    void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        UpdateUIText();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateUIText();

        if (scene.buildIndex == 4 || scene.buildIndex == 5 || scene.name == "Main Menu")
        {
            HideUI();
        }
        else
        {
            ShowUI();
        }

        if (scene.buildIndex == 4) // Assuming 4 is your game over scene index
        {
            DestroyScenePersist();
        }
    }

    public void ResetAll()
    {
        score = 0;
        playerLives = 3;
        UpdateUIText();
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            SceneManager.LoadScene(4); // Load the game over scene (assuming index 4)
        }
    }

    void TakeLife()
    {
        playerLives--;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        UpdateUIText();
    }

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        UpdateUIText();
    }

    void UpdateUIText()
    {
        if (livesText != null)
        {
            livesText.text = playerLives.ToString();
        }

        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }

    public void HideUI()
    {
        if (livesText != null)
        {
            livesText.enabled = false;
        }

        if (scoreText != null)
        {
            scoreText.enabled = false;
        }

        if (coinImage != null) // Hide the coin image
        {
            coinImage.enabled = false;
        }
    }

    public void ShowUI()
    {
        if (livesText != null)
        {
            livesText.enabled = true;
        }

        if (scoreText != null)
        {
            scoreText.enabled = true;
        }

        if (coinImage != null) // Show the coin image
        {
            coinImage.enabled = true;
        }
    }

    public void ReplayGame()
    {
        ResetAll();
        SceneManager.LoadScene(1); // Assuming scene 1 is the starting level
    }

    void DestroyScenePersist()
    {
        ScenePersist scenePersist = FindObjectOfType<ScenePersist>();
        if (scenePersist != null)
        {
            scenePersist.ResetScenePersist();
        }
    }

    public int GetScore()
    {
        return score;
    }
}
