using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class DefenseRunning : GameState
{
    //임시 데이터
    float _monDelay = 1f;
    float _monCount = 50;

    //실사용 데이터
    float _monTime = 0f;
    float _nowMonsterCount = 0;
    public override void OnEnter()
    {
        GenericSingleton<UIData>.Instance.Init();
        var unitList = GenericSingleton<RTSController>.Instance.getUnitList;
    }
    public override void MainLoop()
    {
        makeMonsterLoop();
    }

    void makeMonsterLoop()
    {
        _monTime += Time.deltaTime;
        if (_monTime >= _monDelay && _nowMonsterCount < _monCount)
        {
            //MonsterManager.getInstance().AddMonster();
            GenericSingleton<MonsterManager>.Instance.AddMonster();
            _monTime = 0f;
            _nowMonsterCount++;
        }
    }
    IEnumerator CoWhile()
    {
        yield return new WaitForSecondsRealtime(1f);
    }
}
