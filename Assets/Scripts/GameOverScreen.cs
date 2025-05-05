using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI scoreText;

    public void Setup(int score) {
        gameObject.SetActive(true);
        scoreText.text = "Score: " + score.ToString();
    }

    public void RestartButton() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }
    public void MenuButton() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartScene");
    }
}
