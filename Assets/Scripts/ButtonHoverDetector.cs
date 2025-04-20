using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHoverDetector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Vector3 scaleChange = new Vector3(0.1f, 0.1f, 0); // Customize as needed
    private RectTransform rectTransform;
    private Vector3 originalScale;
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        CursorController.Instance.SetCursor(CursorController.CursorState.Normal);
        rectTransform = GetComponent<RectTransform>();
        originalScale = rectTransform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("Mouse entered button!");
        rectTransform.localScale = originalScale + scaleChange;
        //Debug.Log(rectTransform.localScale);
        CursorController.Instance.SetCursor(CursorController.CursorState.Hover);
    }

    public void OnMouseDown()
    {
        Debug.Log("clicking button");
        CursorController.Instance.SetCursor(CursorController.CursorState.Click);
    }
    public void OnMouseUp()
    {
        CursorController.Instance.SetCursor(CursorController.CursorState.Hover);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("Mouse exited button!");
        rectTransform.localScale = originalScale;
        CursorController.Instance.SetCursor(CursorController.CursorState.Normal);
        // End hover logic here
    }
}
