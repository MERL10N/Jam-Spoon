using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHoverDetector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject gameObject;
    private Vector3 scaleChange;
    void Start()
    {
        scaleChange = new Vector3(0.05f, 0.05f, 0.05f);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse entered button!");
        transform.localScale += scaleChange;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse exited button!");
        transform.localScale -= scaleChange;
        // End hover logic here
    }
}
