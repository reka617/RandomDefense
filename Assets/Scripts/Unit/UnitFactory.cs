using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFactory : MonoBehaviour
{
    List<UnitFactoryBase> unitFactories = new List<UnitFactoryBase>();
    

    //public static UnitFactory getInstance()
    //{
    //    if (_instance == null)
    //    {
    //        GameObject temp = new GameObject();
    //        _instance = temp.AddComponent<UnitFactory>();
    //        DontDestroyOnLoad(temp);
    //    }
    //    return _instance;
    //}

    void Init()
    {
        if (unitFactories.Count > 0) return;
        unitFactories.Add(new BigCapsuleFactory());
        unitFactories.Add(new SmallCapsuleFactory());
        unitFactories.Add(new BIgCubeFactory());
    }

    public Unit BuyRandomUnit()
    {
        Init();
        int i = Random.Range(0, unitFactories.Count);
        return unitFactories[i].MakeUnit();
    }

}

public abstract class UnitFactoryBase
{
    public abstract Unit MakeUnit();
  
}

public class BigCapsuleFactory : UnitFactoryBase
{
    public override Unit MakeUnit()
    {
        Unit unit = new BigCapsuleUnit();
        UnitStat unitStat = new UnitStat();
        unit.Init(unitStat);
        return unit;
    }

}

public class SmallCapsuleFactory : UnitFactoryBase
{
    public override Unit MakeUnit() 
    {
        Unit unit = new SmallCapsuleUnit();
        UnitStat unitStat = new UnitStat();
        unit.Init(unitStat);
        return unit;
    }
}

public class BIgCubeFactory : UnitFactoryBase
{
    public override Unit MakeUnit()
    {
        Unit unit = new BigCubeUnit();
        UnitStat unitStat = new UnitStat();
        unit.Init(unitStat);
        return unit;
    }
}