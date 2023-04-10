using UnityEngine;
using Utils;

public class UISummon : MonoBehaviour
{
    public void BtnSummonUnit()
    {
        GenericSingleton<UnitFactory>.Instance.buyRandomUnit();
    }
}

public class UnitStat
{
    public float AttackSpeed;
    public float AttackPower;
    public float AttackRange;
    public float MoveSpeed;
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
        _obj = GenericSingleton<UnitPool>.Instance.getPoolObject(EUnitType.CapsuleUnit);
        _obj.transform.localScale = new Vector3(1.2f,1.2f,1.2f);
        _obj.transform.position = new Vector3(Random.Range(-3,3),2,Random.Range(-3,3));
    }
}

public class SmallCapsuleUnit : Unit
{
    public override void Init(UnitStat stat)
    {
        _stat = stat;
        _obj = GenericSingleton<UnitPool>.Instance.getPoolObject(EUnitType.CapsuleUnit);
        _obj.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        _obj.transform.position = new Vector3(Random.Range(-3, 3), 2, Random.Range(-3, 3));
    }
}