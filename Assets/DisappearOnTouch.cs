using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearOnTouch : MonoBehaviour
{
    void OnMouseDown()
    {
        // 큐브를 클릭하면 큐브가 사라지도록 설정합니다.
        gameObject.SetActive(false);
    }
}