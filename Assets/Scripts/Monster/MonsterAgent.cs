using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Utils;

public class MonsterAgent : MonoBehaviour
{
    Monster _monData;
    PathMarkers _paths; // �н��������� ��� �̵�
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
        //��ǥ �����ǰ� �Ÿ� üũ�ؼ� ���� ���������� ������Ʈ
        if (Mathf.Abs(Vector3.Distance(transform.position, _paths.getPaths()[_pathIndex].position)) < 0.45f)
        {
            _pathIndex++;
            if (_pathIndex >= _paths.getPaths().Length) _pathIndex = 0;
        }
        _agent.SetDestination(_paths.getPaths()[_pathIndex].position);
    }
    private void OnTriggerEnter(Collider other)
    {
        // �Ѿ˰� �浹�ϸ� HP ����
        // HP�� 0�� �Ǹ� MonsterManager���� ����
    }
}
