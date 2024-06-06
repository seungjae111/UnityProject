using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public Text timerText; // UI Text 컴포넌트 (타이머를 표시하기 위해)
    public GameController gameController; // 게임 컨트롤러

    void Start()
    {
        if (timerText == null)
        {
            Debug.LogError("Timer Text is not assigned in the Inspector.");
        }

        if (gameController == null)
        {
            Debug.LogError("Game Controller is not assigned in the Inspector.");
        }
    }

    void Update()
    {
        if (gameController != null && gameController.currentTime > 0)
        {
            UpdateTimerText(gameController.currentTime);
        }
        else if (gameController != null && gameController.currentTime <= 0)
        {
            GameOver();
        }
    }

    void UpdateTimerText(float timeRemaining)
    {
        if (timerText != null)
        {
            // 남은 시간을 분:초 형식으로 표시합니다.
            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    void GameOver()
    {
        // 게임 컨트롤러의 GameOver 메서드를 호출합니다.
        if (gameController != null)
        {
            gameController.GameOver();
        }
        Debug.Log("Game Over!");
    }
}
