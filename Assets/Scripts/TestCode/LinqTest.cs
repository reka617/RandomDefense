using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;
using UnityEngine.Pool;

public class LinqTest : MonoBehaviour
{
    Mountain[] _mountains =
    {
        new Mountain(){ Height = 272.5f,Name="남산",Length=2300}, //이니셜 라이저
        new Mountain(){ Height = 630f,Name="관악산",Length=4000},
        new Mountain(){ Height = 350f,Name="북악산",Length=5200},
        new Mountain(){ Height = 1700.5f,Name="설악산",Length=3700},
        new Mountain(){ Height = 2000.5f,Name="한라산",Length=9600},
        new Mountain(){ Height = 2800.5f,Name="백두산",Length=1400}
    };
    void Start()
    {
        //SearchHeight(1000f);
        //SearchLinqHeight(1000f);
        SearhMoutainData();
    }

    void SearhMoutainData()
    {
        var result = from m in _mountains
                     where m.Length > 2500// 어떤 조건의 데이터를 추출할 것인가.
                     orderby m.Height ascending// 어떤 데이터를 기준으로 정렬할 것인가.
                     select m;
        foreach (var m in result)
        {
            Debug.Log("이름은 : "+m.Name+", 높이 :"+m.Height+" , 등산로길이 : "+m.Length);
        }
    }

    void SearchLinqHeight(float height)
    {
        var result = from m in _mountains  // 어떤 데이터 집합에서 가져올 것인가. 
                     where m.Height > height
                     select m; // 어떤 항목을 추출할 것인가.
        foreach(var m in result)
        {
            Debug.Log(m.Height + ", "+m.Name);
        }
    }
    List<Mountain> SearchHeight(float height)
    {
        List<Mountain> ret = new List<Mountain>();
        foreach(Mountain m in _mountains)
        {
            if(m.Height >= height)
            {
                ret.Add(m);
            }
        }
        return ret;
    }

}

public class Mountain 
{
    public float Height;
    public string Name;
    public float Length;
}

