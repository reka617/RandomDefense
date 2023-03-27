using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISummon : MonoBehaviour
{
    public void BtnSummonUnit()
    {
        UnitFactory.getInstance().BuyRandomUnit();
    }
}

public class UnitStat
{
    public float AttackSpeed;
    public float AttackPower;
    public float AttackRange;
    public float MpveSpeed;
}

public abstract class Unit
{
    public EUnitType EType;
    protected GameObject _obj;
    protected UnitStat _stat;

    public abstract void Init(UnitStat stat);

}

public class BigCapsuleUnit : Unit
{
    public override void Init(UnitStat stat)
    {
        _stat = stat;
        _obj = UnitPool.GetInstance().GetPoolObject(EUnitType.CapsuleUnit);
        _obj.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        _obj.transform.position = new Vector3(Random.Range(-3, 3), 2, Random.Range(-3, 3));
    }
}

public class SmallCapsuleUnit : Unit
{
    public override void Init(UnitStat stat)
    {
        _stat = stat;
        _obj = UnitPool.GetInstance().GetPoolObject(EUnitType.CapsuleUnit);
        _obj.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        _obj.transform.position = new Vector3(Random.Range(-3, 3), 2, Random.Range(-3, 3));
    }
}

public class BigCubeUnit : Unit 
{
    public override void Init(UnitStat stat) 
    {
        _stat = stat;
        _obj = UnitPool.GetInstance().GetPoolObject(EUnitType.CubeUnit);
        _obj.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        _obj.transform.position = new Vector3(Random.Range(-3, 3), 2, Random.Range(-3, 3));
    }
}
