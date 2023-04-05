using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MyTestCode : MonoBehaviour
{
    [SerializeField] RectTransform _rect;
    Vector2 _start = Vector2.zero;
    Vector2 _end = Vector2.zero;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _start = Input.mousePosition;
        }
        if(Input.GetMouseButton(0))
        {
            _end = Input.mousePosition;
            DrawDragRect();
        }
    }

    void DrawDragRect()
    {
        _rect.position = (_start + _end) * 0.5f;
        _rect.sizeDelta = new Vector2(Mathf.Abs(_start.x - _end.x), Mathf.Abs(_start.y-_end.y));
    }
}

public class GetValue
{
    public UnitCon getInstance()
    {
        return new UnitCon();
    }
    public PathMarkers getPathmarker()
    {
        return new PathMarkers();
    }
}

public class GetTypeInstance <T> where T : new()
{
    public T getInstance()
    {
        return new T();
    }
}
