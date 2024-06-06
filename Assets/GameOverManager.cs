using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverText; // 게임 오버 텍스트 오브젝트
    public Button restartButton; // 재시작 버튼

    void Start()
    {
        // 게임 오버 텍스트와 재시작 버튼을 비활성화합니다.
        if (gameOverText != null)
        {
            gameOverText.SetActive(false);
        }
        if (restartButton != null)
        {
            restartButton.gameObject.SetActive(false);
            restartButton.onClick.AddListener(RestartGame); // 버튼에 클릭 이벤트 리스너 추가
        }
    }

    public void GameOver()
    {
        // 게임 오버 텍스트와 재시작 버튼을 활성화합니다.
        if (gameOverText != null)
        {
            gameOverText.SetActive(true);
        }
        if (restartButton != null)
        {
            restartButton.gameObject.SetActive(true);
        }
    }

    void RestartGame()
    {
        // 현재 씬을 다시 로드하여 게임을 재시작합니다.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}