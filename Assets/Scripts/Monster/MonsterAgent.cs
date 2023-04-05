using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Utils;

public class MonsterAgent : MonoBehaviour
{
    Monster _monData;
    PathMarkers _paths; // 패스방향으로 계속 이동
    int _pathIndex = 1;
    NavMeshAgent _agent;
    int _nowHP;
    float _speed;
    
    public void Init(Monster monData)
    {
        _monData= monData;
        _paths =GenericSingleton<MonsterManager>.getInstance().getMarkers();
        _agent = GetComponent<NavMeshAgent>();
        _nowHP = _monData.HP;
        _speed = _monData.SPEED;
    }
    private void Update()
    {
        if (_paths == null) return;
        //목표 포지션과 거리 체크해서 다음 포지션으로 업데이트
        if (Mathf.Abs(Vector3.Distance(transform.position, _paths.getPaths()[_pathIndex].position)) < 0.45f)
        {
            _pathIndex++;
            if (_pathIndex >= _paths.getPaths().Length) _pathIndex = 0;
        }
        _agent.SetDestination(_paths.getPaths()[_pathIndex].position);
    }
    private void OnTriggerEnter(Collider other)
    {
        // 총알과 충돌하면 HP 감소
        // HP가 0이 되면 MonsterManager에서 삭제
    }
}
