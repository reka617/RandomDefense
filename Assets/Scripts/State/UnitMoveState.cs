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
                _unit.ChangeUnitState(new UnitAttackState());
            }
            
        }
        //generic singleton<MonsterManger>���� Ÿ�� ���� �޾ƿ���
        //������ ���� �� ���� �ݺ�
    }
}

public class UnitAttackState : UnitState
{
    public override void OnEnter(UnitCon unit)
    {
        base.OnEnter(unit);
    }

    public override void MainLoop() 
    {
        //Ÿ���� �����ؼ� �ش� Ÿ�ٿ��� ����ü�� �߻�
    }
}
