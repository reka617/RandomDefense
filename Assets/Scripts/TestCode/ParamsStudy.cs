using Unity.VisualScripting;
using UnityEngine;

public class ParamsStudy : MonoBehaviour
{
    void Start()
    {
        myFunction(15);
        Debug.Log(myIntFunction());
        myParamFunction(1,2,3,4,5,56456,345,234235,456); //데이터를 전부 받음

        //값 전달과 참조 전달
        int i = 5;
        valueInt(i);
        Debug.Log("Start int i : "+i);

        refInt(ref i);
        inInt(3);
        outInt(out i);
        Debug.Log("Start out int i : "+i);
    }

    void valueInt(int j) // 복사 전달
    {
        j = 10;
        Debug.Log("value int i : "+j);
    }

    void refInt(ref int j) // 참조 전달
    {
        j = 10;
        Debug.Log("ref int j : " + j);
    }

    void inInt(in int j)
    {
        //j = 10; // 입력받은 인자값 수정 불가
    }

    void outInt(out int j) //ref와 비슷하게 참조 전달하는데 반드시 할당해줘야함
    {
        j = 10000; //리턴과 동일
    }

    void myParamFunction(params int[] i) // params 라는 키워드를 통해서 특정타입을 배열로 전달받을수 있다.
    {
        for(int j=0;j<i.Length; j++)
        {
            Debug.Log("my param function : " + i[j]);
        }
    }

    void myFunction(int i)
    {
        Debug.Log(i);
    }

    int myIntFunction()
    {
        return 5;
    }
}

public class paramParent
{
    public virtual void pFunc(params object[] objs)
    {

    }
}

public class paramChild1 : paramParent
{
    public override void pFunc(params object[] objs)
    {
        Debug.Log("HP : " + objs[0]);
        Debug.Log("Attack : " + objs[1]);
    }
}

public class paramChild2 : paramParent
{
    public override void pFunc(params object[] objs)
    {
        base.pFunc(objs);
    }
}