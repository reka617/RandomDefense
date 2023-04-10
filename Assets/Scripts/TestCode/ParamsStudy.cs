using Unity.VisualScripting;
using UnityEngine;

public class ParamsStudy : MonoBehaviour
{
    void Start()
    {
        myFunction(15);
        Debug.Log(myIntFunction());
        myParamFunction(1,2,3,4,5,56456,345,234235,456); //�����͸� ���� ����

        //�� ���ް� ���� ����
        int i = 5;
        valueInt(i);
        Debug.Log("Start int i : "+i);

        refInt(ref i);
        inInt(3);
        outInt(out i);
        Debug.Log("Start out int i : "+i);
    }

    void valueInt(int j) // ���� ����
    {
        j = 10;
        Debug.Log("value int i : "+j);
    }

    void refInt(ref int j) // ���� ����
    {
        j = 10;
        Debug.Log("ref int j : " + j);
    }

    void inInt(in int j)
    {
        //j = 10; // �Է¹��� ���ڰ� ���� �Ұ�
    }

    void outInt(out int j) //ref�� ����ϰ� ���� �����ϴµ� �ݵ�� �Ҵ��������
    {
        j = 10000; //���ϰ� ����
    }

    void myParamFunction(params int[] i) // params ��� Ű���带 ���ؼ� Ư��Ÿ���� �迭�� ���޹����� �ִ�.
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