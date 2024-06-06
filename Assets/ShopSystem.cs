using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSystem : MonoBehaviour
{
    public int additionalTimeCost = 50;
    public int doubleStarsCost = 100;

    public Button additionalTimeButton;
    public Button doubleStarsButton;

    void Start()
    {
        additionalTimeButton.onClick.AddListener(BuyAdditionalTime);
        doubleStarsButton.onClick.AddListener(BuyDoubleStars);

        // 아이템 구매 상태 불러오기
        if (PlayerPrefs.GetInt("AdditionalTimePurchased", 0) == 1)
        {
            additionalTimeButton.interactable = false;
        }

        if (PlayerPrefs.GetInt("DoubleStarsPurchased", 0) == 1)
        {
            doubleStarsButton.interactable = false;
        }
    }

    void BuyAdditionalTime()
    {
        int coins = PlayerPrefs.GetInt("Coins", 0);
        if (coins >= additionalTimeCost)
        {
            coins -= additionalTimeCost;
            PlayerPrefs.SetInt("Coins", coins);

            PlayerPrefs.SetInt("AdditionalTimePurchased", 1); // 상태 저장
            Debug.Log("Additional Time Purchased");

            additionalTimeButton.interactable = false; // 1회성 아이템 사용 후 비활성화
        }
        else
        {
            Debug.Log("Not enough coins to buy additional time!");
        }
    }

    void BuyDoubleStars()
    {
        int coins = PlayerPrefs.GetInt("Coins", 0);
        if (coins >= doubleStarsCost)
        {
            coins -= doubleStarsCost;
            PlayerPrefs.SetInt("Coins", coins);

            PlayerPrefs.SetInt("DoubleStarsPurchased", 1); // 상태 저장
            Debug.Log("Double Stars Purchased");

            doubleStarsButton.interactable = false; // 1회성 아이템 사용 후 비활성화
        }
        else
        {
            Debug.Log("Not enough coins to buy double stars!");
        }
    }
}
