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
            // �ڽ��� ���� ��� �⺻ �� ��ȯ
            return Vector3.zero;
        }
        // ���������� ������ ��Ŀ�� ��ġ�� ��ȯ
        Vector3 latestMarkerPosition = catcherArea.GetChild(catcherArea.childCount - 1).position;
        return latestMarkerPosition;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Vector2 localMousePosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(panelRectTransform, eventData.position, eventData.pressEventCamera, out localMousePosition);

        // �̹��� ��ũ ����
        Image newMarker = Instantiate(markerPrefab, panelRectTransform);
        newMarker.rectTransform.anchoredPosition = localMousePosition;
        currentMarker = newMarker;
    }

    public void SetCatcherTarget()
    {
        if (currentMarker == null) return;

        // ��Ŀ ��ġ ���
        Vector2 localMarkerPosition = currentMarker.rectTransform.anchoredPosition;
        Vector3 catcherTargetPos = GetTargetPositionOnCatcherArea(localMarkerPosition);

        // Ÿ�� ��ġ�� ���� �̵�
        SetCatcherPosition(catcherTargetPos);

        // ��Ŀ ����
        Destroy(currentMarker.gameObject);
    }

    public Vector3 GetTargetPositionOnCatcherArea(Vector2 localMousePosition)
    {
        RectTransform rectTransform = catcherArea.GetComponent<RectTransform>();
        Vector3 catcherAreaDimensions = rectTransform.rect.size;

        // localMousePosition ���� [0, 1] ������ ����
        Vector2 normalizedMousePosition = new Vector2(localMousePosition.x / rectTransform.rect.width, localMousePosition.y / rectTransform.rect.height);

        // normalizedMousePosition�� ����Ͽ� �г� �������� ��ġ�� ���
        Vector2 panelLocalPosition = new Vector2(normalizedMousePosition.x * panelRectTransform.rect.width, normalizedMousePosition.y * panelRectTransform.rect.height);

        // �г� �������� ��ġ�� �� ������Ʈ �������� ��ġ�� ��ȯ
        Vector3 worldPosition = panelRectTransform.TransformPoint(panelLocalPosition);

        // ����� ��ġ�� ����Ͽ� ���� ��ġ�� ���
        return new Vector3(worldPosition.x, worldPosition.y, catcherArea.position.z);
    }

    private void SetCatcherPosition(Vector3 catcherTargetPos)
    {
        // ������ �̵���Ű�� �ڵ� �ۼ�
        catcherArea.position = catcherTargetPos;
    }
}
