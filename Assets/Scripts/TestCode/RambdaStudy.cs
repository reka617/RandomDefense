using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class RambdaStudy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        MyRoutine mr = new MyRoutine();
        mr.StartSync();
        
    }

    void slash()
    {

    }

    void myFunc() => Debug.Log("myFunc ȣ��");

    int addFunc(int a, int b) => a + b;

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class MyRoutine
{
    public void StartSync()
    {
        Task.Run(goSync);
        Task.Run(() => Debug.Log("�����Լ��� �����մϴ�."));
    }

    async Task goSync()
    {
        await Task.Delay(5000);
        Debug.Log("end Delay");
    }

    void myFunc()
    {
        //�ڷ�ƾ �ȵ� , MonoBehaviour�� ���
        //setactive  false ������ ����
        //more effective courtine
    }
}
