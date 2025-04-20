using UnityEngine;



public class dragdrop : MonoBehaviour
{
    public new GameObject gameObject;
    private Vector3 mousePositionOffset;
    private Vector3 scaleChange;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scaleChange = new Vector3(0.05f, 0.05f, 0.05f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 GetWorldMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {
        //Creates offset so that the object moves relative to where it's being clicked, not the center of the object
        mousePositionOffset = gameObject.transform.position - GetWorldMousePosition();
        transform.localScale += scaleChange;
    }

    private void OnMouseUp()
    {
        transform.localScale -= scaleChange;
    }

    private void OnMouseDrag()
    {
        transform.position = GetWorldMousePosition() + mousePositionOffset;
        
    }
}
