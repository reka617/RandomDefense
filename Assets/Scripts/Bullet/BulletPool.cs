using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    List<GameObject> _lstObj = new List<GameObject>();
    GameObject[] _bulletObjs = null;




    public List<GameObject> BulletObjs { get { return _lstObj; } } //�Ӽ����� lstobj��ȯ
    void Init()
    {   
        //bulletobj���� �������� �ε� �� ���
        if (_bulletObjs != null) return;
        _bulletObjs = new GameObject[(int)EBulletType.Max];
        for (int i = 0; i < (int)EBulletType.Max; i++)
        {
            _bulletObjs[i] = Resources.Load("Prefabs/Bullet/" + (EBulletType)i) as GameObject;
        }
    }

    public GameObject getPoolObject(EBulletType eType) // bulletŸ��
    {
        foreach (GameObject data in _lstObj)
        {
            if (data.activeSelf == false && data.GetComponent<BulletCon>().BulletType == eType) // �̹� ������� ���ӿ�����Ʈ�� ���� Ÿ������ üũ
            {
                data.SetActive(true);
                return data;
            }
        }
        Init();
        GameObject temp = Instantiate(_bulletObjs[(int)eType]);//������ ���ӿ�����Ʈ�� ã�Ƽ� ����
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
