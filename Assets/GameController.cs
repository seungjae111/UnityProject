using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private StarSpawner starSpawner;

    public float countdownTime = 60.0f;  // 60초 카운트다운 타이머, 인스펙터에서 조정 가능
    public float currentTime { get; private set; } // 현재 시간을 public으로 설정

    private int score;

    public int Score
    {
        get { return score; }
        private set
        {
            score = Mathf.Max(0, value);
            Debug.Log("Score: " + score);
        }
    }

    void Start()
    {
        score = 0;
        currentTime = countdownTime;

        // 아이템 적용 상태 확인 및 적용
        if (PlayerPrefs.GetInt("AdditionalTimePurchased", 0) == 1)
        {
            AddAdditionalTime(30.0f); // 30초 추가
            PlayerPrefs.SetInt("AdditionalTimePurchased", 0); // 1회성 아이템 사용 후 상태 초기화
            Debug.Log("Additional Time applied: +30 seconds");
        }
        else
        {
            Debug.Log("No Additional Time purchased");
        }

        if (PlayerPrefs.GetInt("DoubleStarsPurchased", 0) == 1)
        {
            starSpawner.DoubleStarCount(); // 별의 개수를 2배로 증가
            PlayerPrefs.SetInt("DoubleStarsPurchased", 0); // 1회성 아이템 사용 후 상태 초기화
            Debug.Log("Double Stars applied: Stars count doubled");
        }
        else
        {
            Debug.Log("No Double Stars purchased");
        }

        starSpawner.OnStarClicked += HandleStarClicked;
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            Debug.Log("Current Time: " + currentTime); // 현재 시간을 출력하여 확인
            if (currentTime <= 0)
            {
                currentTime = 0;
                GameOver();
            }
        }
    }

    private void HandleStarClicked()
    {
        Score += 1;
    }

    public void GameOver()
    {
        Debug.Log("Countdown ended!");

        // 스코어를 PlayerPrefs에 저장
        PlayerPrefs.SetInt("CurrentScore", score);

        // 돈으로 환산하여 저장 (1점당 10코인으로 가정)
        int coins = PlayerPrefs.GetInt("Coins", 0);
        coins += score * 10;
        PlayerPrefs.SetInt("Coins", coins);

        // 타이머 종료 시 GameOver 씬으로 전환
        SceneManager.LoadScene("GameOver");
    }

    public void AddAdditionalTime(float additionalTime)
    {
        currentTime += additionalTime;
        Debug.Log("Current Time after adding additional time: " + currentTime);
    }
}
