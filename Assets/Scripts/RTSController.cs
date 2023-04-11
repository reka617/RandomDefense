using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Utils;

public class RTSController : MonoBehaviour
{
    Rect _dragRect;
    Vector2 _start = Vector2.zero;
    Vector2 _end = Vector2.zero;

    List<UnitCon> selectedUnitList = new List<UnitCon>();
    public List<UnitCon> getUnitList { get { return selectedUnitList; } }
  
    public void ClickSelectUnit(UnitCon unit)
    {
        DeSelectAll();
        SelectUnit(unit);
    }
    public void ShiftClickSelectUnit(UnitCon unit)
    {
        if(selectedUnitList.Contains(unit) == true)
        {
            DeSelectUnit(unit);
        }
        else
        {
            SelectUnit(unit);
        }
    }
    public void DragSelectUnit(UnitCon unit)
    {
        if(selectedUnitList.Contains(unit) == false)
        {
            SelectUnit(unit);
        }
    }
    public void DeSelectAll()
    {
        for(int i = 0; i < selectedUnitList.Count; i++)
        {
            selectedUnitList[i].DeSelectUnit();
        }
        selectedUnitList.Clear();
        GenericSingleton<UIData>.Instance.SetUnitInfo(false);
    }
    void SelectUnit(UnitCon unit)
    {
        unit.SelectUnit();
        selectedUnitList.Add(unit);
        GenericSingleton<UIData>.Instance.SetUnitInfo(true);
    }
    void DeSelectUnit(UnitCon unit)
    {
        unit.DeSelectUnit();
        selectedUnitList.Remove(unit);
        if (selectedUnitList.Count <= 0) GenericSingleton<UIData>.Instance.SetUnitInfo(false);
    }
    public void MoveSelectedUnits(Vector3 dest)
    {
        for(int i = 0; i < selectedUnitList.Count; i++)
        {
            selectedUnitList[i].MoveTo(dest);
        }
    }

    private void Update()
    {
        MouseClick();
        MouseDrag();
    }

    void MouseClick()
    {
        if(Input.GetMouseButtonDown(0))//���� ���
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Unit")))
            {
                UnitCon con = hit.transform.GetComponent<UnitCon>();
                if (con == null) return;
                if(Input.GetKey(KeyCode.LeftShift))
                {
                    GenericSingleton<RTSController>.Instance.ShiftClickSelectUnit(con);
                }
                else
                {
                    GenericSingleton<RTSController>.Instance.ClickSelectUnit(con);
                }
            }
            else
            {
                if(Input.GetKey(KeyCode.LeftShift) == false)
                {
                    DeSelectAll();
                }
            }
        }
        if(Input.GetMouseButtonDown(1))//�̵� ���
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("UnitBase")))
            {
                MoveSelectedUnits(hit.point);
            }
        }
    }
    void MouseDrag()
    {
        if(Input.GetMouseButtonDown(0))
        {
            // ���콺 ���� ������ ����
            // �簢�� ������ ����
            _start = Input.mousePosition;
            _dragRect = new Rect();
        }

        if(Input.GetMouseButton(0))
        {
            _end = Input.mousePosition;

            DrawDragRect();
            // ���� ��ġ ����
            // �簢�� �׸��⸦ ����
        }
        if(Input.GetMouseButtonUp(0))
        {
            CalculateDragRect();
            SelectUnits();

            _start = _end = Vector2.zero;
            DrawDragRect();
            // �簢�� ������ ���
            // ������ ����
            //���� �����ǰ� ���� �������� �ʱ�ȭ
            // �簢�� �׸��⸦ ����
        }
    }
    void DrawDragRect()
    {
        GenericSingleton<UIData>.Instance.getRect.position = (_start + _end) * 0.5f;
        GenericSingleton<UIData>.Instance.getRect.sizeDelta = new Vector2(Mathf.Abs(_start.x - _end.x) * 1280f/Screen.width, Mathf.Abs(_start.y-_end.y)* 720f/Screen.height);
    }

    void CalculateDragRect()
    {
        // ���� ���������� ������ִ� �Լ�
        if(Input.mousePosition.x < _start.x)
        {
            _dragRect.xMin = Input.mousePosition.x;
            _dragRect.xMax = _start.x;
        }
        else
        {
            _dragRect.xMin = _start.x;
            _dragRect.xMax = Input.mousePosition.x;
        }

        if(Input.mousePosition.y < _start.y)
        {
            _dragRect.yMin = Input.mousePosition.y;
            _dragRect.yMax = _start.y;
        }
        else
        {
            _dragRect.yMin = _start.y;
            _dragRect.yMax = Input.mousePosition.y;
        }
    }

    void SelectUnits()
    {
        foreach (GameObject unit in GenericSingleton<UnitPool>.Instance.getUnitLists)
        {
            if (unit.activeSelf == true && unit.GetComponent<UnitCon>() != null)
            {
                if (_dragRect.Contains(Camera.main.WorldToScreenPoint(unit.transform.position)))
                {
                    DragSelectUnit(unit.GetComponent<UnitCon>());
                }
            }
        }
    }
}
