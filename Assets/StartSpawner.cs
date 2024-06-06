using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public delegate void StarClickedHandler();
    public event StarClickedHandler OnStarClicked;
    public GameObject starPrefab;  // 별 프리팹
    public int starCount = 5;      // 생성할 별의 개수
    public float spawnInterval = 2.0f;  // 별 생성 시간 간격
    public float starHeight = 0.0592f;  // 별의 높이 (미터 단위)

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval && starCount > 0)
        {
            SpawnStar();
            timer = 0f;
            starCount--;
        }
    }

    public void DoubleStarCount()
    {
        // 전체 별의 수를 2배로 증가
        starCount *= 2;
    }

    void SpawnStar()
    {
        float x = Random.Range(-70f, 70f);  // 가로 범위 -70cm에서 70cm
        float z = Random.Range(-70f, 70f);  // 세로 범위 -70cm에서 70cm

        Vector3 spawnPosition = new Vector3(x, starHeight, z);
        GameObject star = Instantiate(starPrefab, spawnPosition, Quaternion.identity);

        // 클릭 이벤트 추가
        star.AddComponent<StarClickHandler>().OnStarClicked += HandleStarClicked;
    }

    void HandleStarClicked()
    {
        OnStarClicked?.Invoke();
    }
}

public class StarClickHandler : MonoBehaviour
{
    public delegate void StarClickedHandler();
    public event StarClickedHandler OnStarClicked;

    void OnMouseDown()
    {
        OnStarClicked?.Invoke();
        Destroy(gameObject);
    }
}
