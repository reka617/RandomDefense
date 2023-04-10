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
            //이동종료
            _unit.ChangeUnitState(new UnitSearchState());
        }
        //목적지까지의 남은 거리
        //0이면 상태를 변경한다.
    }

}

public class UnitSearchState : UnitState
{
    float _cooltime = 0; // 반복 시간
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
            _target = GenericSingleton<MonsterManager>.Instance.GetTarget(_unit.transform.position, 3); // 타겟 검색 함수 실행
            if(_target != null ) 
            {
                _unit.ChangeUnitState(new UnitAttackState());
            }
            
        }
        //generic singleton<MonsterManger>한테 타겟 정보 받아오기
        //없으면 있을 때 까지 반복
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
        //타겟을 선택해서 해당 타겟에서 투사체를 발사
    }
}
