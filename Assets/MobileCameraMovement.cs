using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MobileCameraMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Button upButton;
    public Button downButton;
    public Button leftButton;
    public Button rightButton;
    
    // 이동 범위 설정을 위한 변수
    public Vector3 minBounds;
    public Vector3 maxBounds;

    private bool moveUp, moveDown, moveLeft, moveRight;

    void Start()
    {
        // 게임 시작 시 버튼 활성화
        upButton.gameObject.SetActive(true);
        downButton.gameObject.SetActive(true);
        leftButton.gameObject.SetActive(true);
        rightButton.gameObject.SetActive(true);

        upButton.gameObject.AddComponent<UIElement>().Init(() => moveUp = true, () => moveUp = false);
        downButton.gameObject.AddComponent<UIElement>().Init(() => moveDown = true, () => moveDown = false);
        leftButton.gameObject.AddComponent<UIElement>().Init(() => moveLeft = true, () => moveLeft = false);
        rightButton.gameObject.AddComponent<UIElement>().Init(() => moveRight = true, () => moveRight = false);
    }

    void Update()
    {
        Vector3 moveDirection = Vector3.zero;

        if (moveUp) moveDirection += Vector3.forward; // Z 방향으로 이동
        if (moveDown) moveDirection += Vector3.back; // Z 방향으로 이동
        if (moveLeft) moveDirection += Vector3.left; // X 방향으로 이동
        if (moveRight) moveDirection += Vector3.right; // X 방향으로 이동

        Vector3 newPosition = transform.position + moveDirection * moveSpeed * Time.deltaTime;
        
        // 카메라 위치를 이동 범위 내로 제한
        newPosition.x = Mathf.Clamp(newPosition.x, minBounds.x, maxBounds.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minBounds.y, maxBounds.y);
        newPosition.z = Mathf.Clamp(newPosition.z, minBounds.z, maxBounds.z);

        transform.position = newPosition;
    }
}

public class UIElement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private System.Action onPointerDown;
    private System.Action onPointerUp;

    public void Init(System.Action onPointerDown, System.Action onPointerUp)
    {
        this.onPointerDown = onPointerDown;
        this.onPointerUp = onPointerUp;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        onPointerDown?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        onPointerUp?.Invoke();
    }
}
