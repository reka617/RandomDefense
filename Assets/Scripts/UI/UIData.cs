using UnityEngine;

public class UIData : MonoBehaviour
{
    GameObject _uiMain;
    UIManager _manager;
    public void Init()
    {
        if (_uiMain != null) return;
        _uiMain = Resources.Load("Prefabs/UIMain") as GameObject;
        _manager = Instantiate(_uiMain).GetComponent<UIManager>();
    }

    public RectTransform getRect
    {
        get
        {
            return _manager.getRectUI;
        }
    }
    public void SetUnitInfo(bool _isOpen)
    {
        _manager.UnitInfoOnOff(_isOpen);
    }
}
