using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RankSystem : MonoBehaviour
{
    [SerializeField]
    private int maxRankCount = 5;
    [SerializeField]
    private GameObject textPrefab;
    [SerializeField]
    private Transform panelRankInfo;

    private List<RankData> rankDataList;

    void Start()
    {
        LoadRankData();
        int currentScore = PlayerPrefs.GetInt("CurrentScore", 0);
        UpdateRank(currentScore);
        DisplayRankInfo();
    }

    private void LoadRankData()
    {
        rankDataList = new List<RankData>();
        for (int i = 1; i <= maxRankCount; i++)
        {
            int score = PlayerPrefs.GetInt("Rank" + i, -1);
            if (score != -1)
            {
                rankDataList.Add(new RankData(i, score));
            }
        }
    }

    public void SaveRankData()
    {
        for (int i = 0; i < rankDataList.Count; i++)
        {
            PlayerPrefs.SetInt("Rank" + (i + 1), rankDataList[i].score);
        }
        PlayerPrefs.Save();
    }

    public void UpdateRank(int newScore)
    {
        if (newScore <= 0) return; // 0점 이하의 스코어는 랭크에 추가하지 않음
        
        RankData newRankData = new RankData(0, newScore);
        rankDataList.Add(newRankData);
        rankDataList.Sort((x, y) => y.score.CompareTo(x.score));

        if (rankDataList.Count > maxRankCount)
        {
            rankDataList.RemoveAt(maxRankCount);
        }

        for (int i = 0; i < rankDataList.Count; i++)
        {
            rankDataList[i].rank = i + 1;
        }

        SaveRankData();
        DisplayRankInfo();
    }

    private void DisplayRankInfo()
    {
        foreach (Transform child in panelRankInfo)
        {
            Destroy(child.gameObject);
        }

        foreach (var rankData in rankDataList)
        {
            GameObject textInstance = Instantiate(textPrefab, panelRankInfo);
            TextMeshProUGUI textComponent = textInstance.GetComponent<TextMeshProUGUI>();
            if (textComponent != null)
            {
                textComponent.text = $"Rank: {rankData.rank}, Score: {rankData.score}";
            }
        }
    }
}
