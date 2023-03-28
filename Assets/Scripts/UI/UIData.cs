using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIData : MonoBehaviour
{
    GameObject _uiMain;
    UIManager _uiManager;
    public void Init()
    {
        if (_uiMain != null) return;
        _uiMain = Resources.Load("Prefabs/UIMain") as GameObject;
        _uiManager = Instantiate(_uiMain).GetComponent<UIManager>();
    }
}
