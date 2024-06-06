using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableBlockOnStart : MonoBehaviour
{
    void Start()
    {
        // 이 스크립트가 부착된 게임 오브젝트를 비활성화합니다.
        gameObject.SetActive(false);
    }
}