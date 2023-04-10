using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SubsystemsImplementation;

public class UnitPool : MonoBehaviour
{
    List<GameObject> _lstObj = new List<GameObject>();
    GameObject[] _unitObjs = null;
    //private static UnitPool _instance;
    //public static UnitPool GetInstance()
    //{
    //    if(_instance == null)
    //    {
    //        GameObject temp = new GameObject();
    //        _instance = temp.AddComponent<UnitPool>();
    //        DontDestroyOnLoad(temp);
    //    }
    //    return _instance;
    //}

    void Init()
    {
        if (_unitObjs != null) return;
        _unitObjs = new GameObject[(int)EUnitType.Max];
        for(int i = 0; i < (int)EUnitType.Max; i++)
        {
            _unitObjs[i] = Resources.Load("Prefabs/"+(EUnitType)i) as GameObject;
        }
    }

    public List<GameObject> getUnitLists
    {
        get
        {
            return _lstObj;
        }
    }

    public GameObject getPoolObject(EUnitType eType)
    {
        foreach(GameObject data in _lstObj)
        {
            if(data.activeSelf == false && data.GetComponent<UnitCon>().getUnitType == eType) // 이미 만들어진 게임오브젝트가 같은 타입인지 체크
            {
                data.SetActive(true);
                return data;
            }
        }
        Init();
        GameObject temp = Instantiate(_unitObjs[(int)eType]);//적당한 게임오브젝트를 찾아서 생성
        _lstObj.Add(temp);
        return temp;
    }

    public void clearPoolObject()
    {
        foreach(GameObject obj in _lstObj)
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
    Max,
}