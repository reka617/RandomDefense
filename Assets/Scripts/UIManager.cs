using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject _invenUI;
    [SerializeField] GameObject _saleUI;

    public void BtnInvenOnOff()
    {
        _invenUI.SetActive(_invenUI.activeSelf == false);
    }

    public void BtnSaleOnOff()
    {
        _saleUI.SetActive(_saleUI.activeSelf == false);
    }
}
