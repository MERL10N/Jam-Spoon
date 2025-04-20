using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHoverDetector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Vector3 scaleChange = new Vector3(0.1f, 0.1f, 0); // Customize as needed
    private RectTransform rectTransform;
    private Vector3 originalScale;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalScale = rectTransform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse entered button!");
        rectTransform.localScale = originalScale + scaleChange;
        Debug.Log(rectTransform.localScale);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse exited button!");
        rectTransform.localScale = originalScale;
        // End hover logic here
    }
}
