using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCon : MonoBehaviour
{
    private EBulletType eType;
    public EBulletType BulletType { get { return eType; } }

    private MonsterAgent _target;

    public MonsterAgent Target { get { return _target; }set { _target = value; } }

    private int _speed = 15;

    private void Update()
    {
        MoveToTarget();
        CheckDist();
    }

    void MoveToTarget()
    {
        if(_target == null) return;
        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, Time.deltaTime*_speed);
    }

    void CheckDist()
    {
        if (_target == null) return;
        if(Vector3.Distance(_target.transform.position, transform.position) < 0.1f)
        {
            _target = null;
            gameObject.SetActive(false);
        }
    }
}