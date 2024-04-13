using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IDragHandler
{
    private RectTransform rectTransform;
    public Canvas canvas;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Adjust position based on mouse and the calculated offset
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

}