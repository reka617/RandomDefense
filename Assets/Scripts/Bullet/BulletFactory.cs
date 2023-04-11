using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;


public enum EBulletType
{
    fastBullet,
    slowBullet,
    Max
}
public class BulletFactory : MonoBehaviour
{
    List<BulletFactoryBase> bulletFactories = new List<BulletFactoryBase>(); // 리스트의 인덱스를 EBulletType과 매칭

    void Init()
    {
        if (bulletFactories.Count > 0) return;
        bulletFactories.Add(new FastBulletFactory());
        bulletFactories.Add(new SlowBulletFactory());
        
    }

    public Bullet MakeBullet(EBulletType eType, int dmg, MonsterAgent ma, Vector3 from)
    {
        Init();
        return bulletFactories[(int)eType].MakeBullet(dmg, ma, from);
    }
}

public abstract class Bullet
{
    protected GameObject _obj;
    protected MonsterAgent _target;
    protected int _dmg;

    public abstract void Init(int dmg, MonsterAgent target, Vector3 from);
}

public class FastBullet : Bullet
{
    public override void Init(int dmg, MonsterAgent target, Vector3 from)
    {
        _target= target;
        _dmg=dmg;
        _obj = GenericSingleton<BulletPool>.Instance.getPoolObject(EBulletType.fastBullet);
        _obj.transform.position = from;
        //타겟세팅 // bullet 프리팹에 bullet을 제어할 컨트롤러 만들어서 세팅
        if (_obj.GetComponent<BulletCon>() != null) _obj.GetComponent<BulletCon>().Target = target;
    }
}

public class SlowBullet : Bullet
{
    public override void Init(int dmg, MonsterAgent target, Vector3 from)
    {
        _target = target;
        _dmg = dmg;
        _obj = GenericSingleton<BulletPool>.Instance.getPoolObject(EBulletType.slowBullet);
        _obj.transform.position = from;
        if (_obj.GetComponent<BulletCon>() != null) _obj.GetComponent<BulletCon>().Target = target;
    }
}

public abstract class BulletFactoryBase
{
    public abstract Bullet MakeBullet(int dmg, MonsterAgent ma, Vector3 from);
}

public class FastBulletFactory : BulletFactoryBase
{
    public override Bullet MakeBullet(int dmg, MonsterAgent ma, Vector3 from)
    {
        Bullet b = new FastBullet();
        b.Init(dmg, ma, from);
        return b;
    }
}

public class SlowBulletFactory : BulletFactoryBase
{
    public override Bullet MakeBullet(int dmg, MonsterAgent ma, Vector3 from)
    {
        Bullet b = new SlowBullet();
        b.Init(dmg, ma, from);
        return b;
    }
}