using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    List<GameObject> _lstObj = new List<GameObject>();
    GameObject[] _bulletObjs = null;




    public List<GameObject> BulletObjs { get { return _lstObj; } } //속성으로 lstobj반환
    void Init()
    {   
        //bulletobj에서 프리팹을 로드 후 등록
        if (_bulletObjs != null) return;
        _bulletObjs = new GameObject[(int)EBulletType.Max];
        for (int i = 0; i < (int)EBulletType.Max; i++)
        {
            _bulletObjs[i] = Resources.Load("Prefabs/Bullet/" + (EBulletType)i) as GameObject;
        }
    }

    public GameObject getPoolObject(EBulletType eType) // bullet타입
    {
        foreach (GameObject data in _lstObj)
        {
            if (data.activeSelf == false && data.GetComponent<BulletCon>().BulletType == eType) // 이미 만들어진 게임오브젝트가 같은 타입인지 체크
            {
                data.SetActive(true);
                return data;
            }
        }
        Init();
        GameObject temp = Instantiate(_bulletObjs[(int)eType]);//적당한 게임오브젝트를 찾아서 생성
        _lstObj.Add(temp);
        return temp;
    }

    public void clearPoolObject()
    {
        foreach (GameObject obj in _lstObj)
        {
            Destroy(obj);
        }
        _lstObj.Clear();
    }
}
