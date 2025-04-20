using System;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public enum CursorState
    {
        Normal = 0,
        Hover,
        Click
    }
    
    [SerializeField]
    private Texture2D normalCursor;
    [SerializeField]
    private Texture2D hoverCursor;

    [SerializeField] private Texture2D clickCursor;

    public static CursorController Instance;

    public void Awake()
    {
        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SetCursor(CursorState state)
    {
        ChangeCursor(state);
    }

    private void ChangeCursor(CursorState state)
    {
        switch (state)
        {
            case CursorState.Normal:
                Cursor.SetCursor(normalCursor, Vector2.zero, CursorMode.Auto);
                break;
            case CursorState.Hover:
                Cursor.SetCursor(hoverCursor, Vector2.zero, CursorMode.Auto);
                break;
            case CursorState.Click:
                Cursor.SetCursor(clickCursor, Vector2.zero, CursorMode.Auto);
                break;
            default:
                Cursor.SetCursor(normalCursor, Vector2.zero, CursorMode.Auto);
                break;
        }
    }
}
