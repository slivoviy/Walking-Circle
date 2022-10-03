using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager Singleton;
    public bool gameOver;
    
    [SerializeField] private int coinsAmount;
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI gameOverText;

    private int coinsCollected;

    private void Awake() {
        Singleton = this;
    }
    
    private void UpdateCoins(int coins) {
        coinsText.text = coins.ToString();
    }
    
    public void AddCoin() {
        ++coinsCollected;
        if (coinsCollected == coinsAmount) {
            UpdateCoins(coinsCollected);
            GameOver(true);
        }
        else {
            UpdateCoins(coinsCollected);
        }
    }

    public void GameOver(bool gameWon) {
        gameOver = true;
        Time.timeScale = 0f;
        gameOverText.text = gameWon ? "You won!" : "You lost!";
        gameOverPanel.SetActive(true);
    }

    public void RestartGame() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}