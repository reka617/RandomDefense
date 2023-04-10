using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MonsterManager : MonoBehaviour
{
    PathMarkers _marker; // �н� ��Ŀ ����
    List<MonsterAgent> _monster = new List<MonsterAgent>();    // ���� ����Ʈ�� ����

    GameObject _cubeMonster;

    //public static MonsterManager getInstance()
    //{
    //    if(_instance == null)
    //    {
    //        GameObject temp = new GameObject();
    //        _instance = temp.AddComponent<MonsterManager>();
    //        DontDestroyOnLoad(temp);
    //    }
    //    return _instance;
    //}

    public PathMarkers getMarkers
    {
        get
        {
            if (_marker == null)
            {
                GameObject temp = Resources.Load("Prefabs/PathMarkerBase") as GameObject;
                _marker = Instantiate(temp).GetComponent<PathMarkers>();
                DontDestroyOnLoad(temp);
            }
            return _marker;
        }
        
    }

    public void AddMonster()
    {
        if(_cubeMonster == null)
        {
            _cubeMonster = Resources.Load("Prefabs/CubeMonster") as GameObject;
        }
        var mark = getMarkers;
        MonsterAgent mon = Instantiate(_cubeMonster).GetComponent<MonsterAgent>();
        mon.transform.position = _marker.getPaths[0].position;
        // �ӽ� �ڵ�
        Monster tempMon = new Monster();
        tempMon.HP = 10;
        tempMon.SPEED = 5.0f;
        tempMon.NAME = "ť�� ����";
        tempMon.EDefTYPE = EDefType.None;
        // �������
        mon.Init(tempMon);
        _monster.Add(mon);
    }

    public MonsterAgent GetTarget(Vector3 position, float dist)
    {
        MonsterAgent ret = (from m in _monster
                           where Vector3.Distance(position, m.transform.position) < dist
                           orderby Vector3.Distance(m.transform.position, position) ascending
                           select m).FirstOrDefault(); // FirstOrDefault ������ �����ϴ� ��� �� ���� ���ǿ� ����� ��� �ϳ� //Take()�Լ��� ���� �Ŀ� ���µ� Take(3)�ϸ� ���ĵȰ� ���������� 3�� �̾��� 
        
        return ret;
    }

    // ���͸� ��ȯ�մϴ�.
    // ���͸� �ʱ�ȭ�մϴ�.
    // ���͸� �����մϴ�.
}


public class Monster
{
    public int HP;
    public float SPEED;
    public string NAME;
    public EDefType EDefTYPE;
}

public enum EDefType
{
    None,
    Magic,
    Physics,
}