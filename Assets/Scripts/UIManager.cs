using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
    public static UIManager Singleton;
    public bool gameOver;

    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI gameOverText;

    private void Awake() {
        Singleton = this;
    }

    public void AddCoin(int coins) {
        coinsText.text = coins.ToString();
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