using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class RTSController : MonoBehaviour
{
    List<UnitCon> selectedUnitList = new List<UnitCon>();

    public List<UnitCon> getUnitList()
    {
        return selectedUnitList;
    }

    public void ClickSelectUnit(UnitCon unit)
    {
        DeSelctAll();
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

    public void DeSelctAll()
    {
        for(int i=0; i< selectedUnitList.Count;i++)
        {
            selectedUnitList[i].DeselectUnit();
        }
        selectedUnitList.Clear();
    }

    void SelectUnit(UnitCon unit)
    {
        unit.SelectUnit();
        selectedUnitList.Add(unit);
    }

    void DeSelectUnit(UnitCon unit)
    {
        unit.DeselectUnit();
        selectedUnitList.Remove(unit);
    }

    public void MoveSelectUnits(Vector3 dest)
    {
        for(int i=0;i< selectedUnitList.Count;i++) 
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
        if(Input.GetMouseButtonDown(0)) // 선택명령
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity,1 << LayerMask.NameToLayer("Unit")))
            {
                UnitCon con = hit.transform.GetComponent<UnitCon>();
                if (con == null) return;
                if(Input.GetKey(KeyCode.LeftShift)) 
                {
                    GenericSingleton<RTSController>.getInstance().ShiftClickSelectUnit(con);
                }
                else
                {
                    GenericSingleton<RTSController>.getInstance().ClickSelectUnit(con); 
                }

            }
        }
        if (Input.GetMouseButtonDown(1)) // 이동명령
        {
            
        }
    }

    void MouseDrag()
    {

    }
}
