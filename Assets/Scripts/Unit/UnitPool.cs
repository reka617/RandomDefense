using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPool : MonoBehaviour
{
    List<GameObject> _lstObj = new List<GameObject>();
    private static UnitPool _instance;
    GameObject[] _unitObjs = null;

    //public static UnitPool GetInstance()
    //{
    //    if (_instance == null)
    //    {
    //        GameObject go = new GameObject("UnitPool");
    //        _instance = go.AddComponent<UnitPool>();
    //        DontDestroyOnLoad(_instance);
    //    }

    //    return _instance;
    //}

    void Init()
    {
        if (_unitObjs != null) return;
        _unitObjs = new GameObject[(int)EUnitType.Max];
        for (int i = 0; i < (int)EUnitType.Max; i++)
        {
            _unitObjs[i] = Resources.Load("Prefabs/Unit/" + (EUnitType)i) as GameObject;
        }
    }

    public GameObject GetPoolObject(EUnitType eType)
    {
        foreach (GameObject obj in _lstObj)
        {
            if (obj.activeSelf == false && obj.GetComponent<UnitCon>().GetUnitType() == eType) // �̹� ������� ���ӿ�����Ʈ�� ���� Ÿ������ üũ
            {
                return obj;
            }
        }
        Init();
        GameObject temp = Instantiate(_unitObjs[(int)eType]); // Instantiate(); // ������ ���ӿ�����Ʈ ����
        _lstObj.Add(temp);
        return temp;
    }

    public void ClearPoolObject()
    {
        foreach (GameObject obj in _lstObj)
        {
            Destroy(obj);
        }

        _lstObj.Clear();
    }
}

public enum EUnitType
{
    None,
    CapsuleUnit,
    CubeUnit,
    SphereUnit,
    CylinderUnit,
    Max
}