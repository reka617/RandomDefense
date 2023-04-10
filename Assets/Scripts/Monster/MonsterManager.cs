using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MonsterManager : MonoBehaviour
{
    PathMarkers _marker; // 패스 마커 저장
    List<MonsterAgent> _monster = new List<MonsterAgent>();    // 몬스터 리스트를 저장

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
        // 임시 코드
        Monster tempMon = new Monster();
        tempMon.HP = 10;
        tempMon.SPEED = 5.0f;
        tempMon.NAME = "큐브 몬스터";
        tempMon.EDefTYPE = EDefType.None;
        // 여기까지
        mon.Init(tempMon);
        _monster.Add(mon);
    }

    public MonsterAgent GetTarget(Vector3 position, float dist)
    {
        MonsterAgent ret = (from m in _monster
                           where Vector3.Distance(position, m.transform.position) < dist
                           orderby Vector3.Distance(m.transform.position, position) ascending
                           select m).FirstOrDefault(); // FirstOrDefault 조건을 만족하는 경우 중 가장 조건에 가까운 경우 하나 //Take()함수는 정렬 후에 쓰는데 Take(3)하면 정렬된거 위에서부터 3개 뽑아줌 
        
        return ret;
    }

    // 몬스터를 소환합니다.
    // 몬스터를 초기화합니다.
    // 몬스터를 삭제합니다.
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