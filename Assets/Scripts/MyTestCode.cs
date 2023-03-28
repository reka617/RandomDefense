using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTestCode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetTypeInstance<UnitCon> gti = new GetTypeInstance<UnitCon>();
        UnitCon uc = gti.getInstance();
        GetTypeInstance<PathMarkers> gti2 = new GetTypeInstance<PathMarkers>();
        PathMarkers pm = gti2.getInstance();
        
    }

}

public class GetValue
{
    public UnitCon getInstance()
    {
        return new UnitCon();
    }
}

public class GetTypeInstance<T> where T : new()
{
    public T getInstance()
    {
        return new T();
    }
}

