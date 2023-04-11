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

    void myFunc() => Debug.Log("myFunc 호출");

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
        Task.Run(() => Debug.Log("무명함수를 실행합니다."));
    }

    async Task goSync()
    {
        await Task.Delay(5000);
        Debug.Log("end Delay");
    }

    void myFunc()
    {
        //코루틴 안됨 , MonoBehaviour가 없어서
        //setactive  false 동작을 안함
        //more effective courtine
    }
}
