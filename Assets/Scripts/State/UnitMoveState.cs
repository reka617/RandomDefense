using System.Collections.Generic;
using UnityEngine;
using Utils;

public class UnitMoveState : UnitState
{
    public override void OnEnter(UnitCon unit)
    {
        base.OnEnter(unit);
    }

    public override void MainLoop()
    {
        base.MainLoop();
    }

    void CheckMoveEnd()
    {
        if (_unit.isMoveEnd() == true)
        {
            //�̵�����
            _unit.ChangeUnitState(new UnitSearchState());
        }
        //������������ ���� �Ÿ�
        //0�̸� ���¸� �����Ѵ�.
    }

}

public class UnitSearchState : UnitState
{
    float _cooltime = 0; // �ݺ� �ð�
    MonsterAgent _target = null;
    public override void OnEnter(UnitCon unit)
    {
        base.OnEnter(unit);
    }

    public override void MainLoop() 
    {
        _cooltime += Time.deltaTime;
        if (_cooltime >= 1f)
        {
            _cooltime= 0f;
            _target = GenericSingleton<MonsterManager>.Instance.GetTarget(_unit.transform.position, 3); // Ÿ�� �˻� �Լ� ����
            if(_target != null ) 
            {
                Debug.Log("Ÿ��ã��");  
                _unit.ChangeUnitState(new UnitAttackState());
            }
            
        }
        //generic singleton<MonsterManger>���� Ÿ�� ���� �޾ƿ���
        //������ ���� �� ���� �ݺ�
    }
}

public class UnitAttackState : UnitState
{
    List<UnitCon> _lstUnit = new List<UnitCon>();
    public override void OnEnter(UnitCon unit)
    {
        base.OnEnter(unit);
    }

    public override void MainLoop() 
    {
        _lstUnit = GenericSingleton<RTSController>.Instance.getUnitList;
        //Ÿ���� �����ؼ� �ش� Ÿ�ٿ��� ����ü�� �߻�
        for (int i = 0; _lstUnit.Count < _lstUnit.Count; i++)
        {
            MonsterAgent target = GenericSingleton<MonsterManager>.Instance.GetTarget(_lstUnit[i].transform.position, 5);
            if (target != null)
            {
                GenericSingleton<BulletFactory>.Instance.MakeBullet(EBulletType.fastBullet, 10, target, _lstUnit[i].transform.position);
                _lstUnit[i].ChangeUnitState(new UnitSearchState());
            }
        }
    }
}
