using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickHandler : MonoBehaviour, IPointerClickHandler
{
    public Image markerPrefab;
    public Transform catcherArea;
    public RectTransform panelRectTransform;
    private Image currentMarker;

    public Vector3 GetCurrentTargetPosition()
    {
        if (catcherArea.childCount == 0)
        {
            // 자식이 없을 경우 기본 값 반환
            return Vector3.zero;
        }
        // 마지막으로 생성한 마커의 위치를 반환
        Vector3 latestMarkerPosition = catcherArea.GetChild(catcherArea.childCount - 1).position;
        return latestMarkerPosition;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Vector2 localMousePosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(panelRectTransform, eventData.position, eventData.pressEventCamera, out localMousePosition);

        // 이미지 마크 생성
        Image newMarker = Instantiate(markerPrefab, panelRectTransform);
        newMarker.rectTransform.anchoredPosition = localMousePosition;
        currentMarker = newMarker;
    }

    public void SetCatcherTarget()
    {
        if (currentMarker == null) return;

        // 마커 위치 계산
        Vector2 localMarkerPosition = currentMarker.rectTransform.anchoredPosition;
        Vector3 catcherTargetPos = GetTargetPositionOnCatcherArea(localMarkerPosition);

        // 타깃 위치로 포수 이동
        SetCatcherPosition(catcherTargetPos);

        // 마커 제거
        Destroy(currentMarker.gameObject);
    }

    public Vector3 GetTargetPositionOnCatcherArea(Vector2 localMousePosition)
    {
        RectTransform rectTransform = catcherArea.GetComponent<RectTransform>();
        Vector3 catcherAreaDimensions = rectTransform.rect.size;

        // localMousePosition 값을 [0, 1] 범위로 변경
        Vector2 normalizedMousePosition = new Vector2(localMousePosition.x / rectTransform.rect.width, localMousePosition.y / rectTransform.rect.height);

        // normalizedMousePosition을 사용하여 패널 내에서의 위치를 계산
        Vector2 panelLocalPosition = new Vector2(normalizedMousePosition.x * panelRectTransform.rect.width, normalizedMousePosition.y * panelRectTransform.rect.height);

        // 패널 내에서의 위치를 빈 오브젝트 내에서의 위치로 변환
        Vector3 worldPosition = panelRectTransform.TransformPoint(panelLocalPosition);

        // 변경된 위치를 사용하여 포수 위치를 계산
        return new Vector3(worldPosition.x, worldPosition.y, catcherArea.position.z);
    }

    private void SetCatcherPosition(Vector3 catcherTargetPos)
    {
        // 포수를 이동시키는 코드 작성
        catcherArea.position = catcherTargetPos;
    }
}
