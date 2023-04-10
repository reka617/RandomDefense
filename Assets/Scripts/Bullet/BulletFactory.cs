using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EBulletType
{
    fastBullet,
    slowBullet,
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

    public Bullet MakeBullet(EBulletType eType)
    {
        Init();
        return bulletFactories[(int)eType].MakeBullet();
    }
}

public class Bullet
{

}


public abstract class BulletFactoryBase
{
    public abstract Bullet MakeBullet();
}

public class FastBulletFactory : BulletFactoryBase
{
    public override Bullet MakeBullet()
    {
        Bullet b = new Bullet();
        return b;
    }
}

public class SlowBulletFactory : BulletFactoryBase
{
    public override Bullet MakeBullet()
    {
        Bullet b = new Bullet();
        return b;
    }
}