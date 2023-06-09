using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject _invenUI;
    [SerializeField] GameObject _saleUI;
    [SerializeField] RectTransform _drawRect;
    [SerializeField] GameObject _unitInfoPanel;
    public RectTransform getRectUI { get { return _drawRect; } }

    public void UnitInfoOnOff(bool _isOpen)
    {
        _unitInfoPanel.SetActive(_isOpen);
    }

    public void BtnInvenOnOff()
    {
        _invenUI.SetActive(_invenUI.activeSelf == false);
    }

    public void BtnSaleOnOff()
    {
        _saleUI.SetActive(_saleUI.activeSelf == false);
    }
}
