using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LinqTest : MonoBehaviour
{
    Mountain[] _mountains =
    {
        new Mountain(){ Height = 272.5f,Name="����",Length=2300}, //�̴ϼ� ������
        new Mountain(){ Height = 630f,Name="���ǻ�",Length=4000},
        new Mountain(){ Height = 350f,Name="�Ͼǻ�",Length=5200},
        new Mountain(){ Height = 1700.5f,Name="���ǻ�",Length=3700},
        new Mountain(){ Height = 2000.5f,Name="�Ѷ��",Length=9600},
        new Mountain(){ Height = 2800.5f,Name="��λ�",Length=1400}
    };
    void Start()
    {
        //SearchHeight(1000f);
        SearchMountainData();
    }

    void SearchMountainData()
    {
        var result = from m in _mountains
                     where m.Length >= 2500 
                     orderby m.Height ascending
                     select m;

        foreach(var m in result) 
        {
            Debug.Log($"�̸��� : {m.Name}, ���� : {m.Height}, ���α��� : {m.Length}");
        }
    }

    void SearchLinqHeight(float height)
    {
        var result = from m in _mountains where m.Height >= height orderby m.Height ascending select m;
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