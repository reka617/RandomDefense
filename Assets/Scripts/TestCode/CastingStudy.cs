using System;
using UnityEngine;

public class CastingSTudy : MonoBehaviour
{
    void Start()
    {
        // 암시적 형변환
        int i = 0;
        i = 10;
        short s = 10;
        i = s; // 형변환 암시적 형변환
        float f = i;
        //대부분 값이 잘리거나 반올림되지 않고 맞출수 있을때 암시적 형변환가능

        Animal ani = new Mammal(); // 상속받은 부모 클래스, 인터페이스로 암시적 변환 항상 가능

        // 명시적 형변환
        s = (short)i; // int보다 작은 타입인 short 로 형변환
        i = (int)f;
        Mammal ma = (Mammal)ani; //그냥은 안되는 상속관계의 형변환
        //Mammal ma2 = (Mammal)new CastingSTudy(); // 상속관계에 없으면 명시적 형변환도 불가

        //함수를 통한 형변환
        string str = i.ToString();
        str = "문자열";
        //Reptile rp = (Reptile)ani;
        try //try - catch 구문
        {
            i = int.Parse(str);
        }
        catch(DivideByZeroException e) //어떤 수를 0으로 나누려고 시도했을때 발생하는 오류
        {
            Debug.LogError("발생한 에러는 : " + e);
        }
        catch(FormatException e) //변환 하려는 형식이 맞지 않을때 오류
        {
            Debug.LogError("발생한 에러는 : " + e);
        }
        catch(NullReferenceException e) //접근하려는 객체가 null일때
        {
            Debug.LogError("발생한 에러는 : " + e);
        }
        catch(InvalidCastException e) //형변환 오류
        {
            Debug.LogError("발생한 에러는 : " + e);
        }
        catch(Exception e)
        {
            Debug.LogError("발생한 에러는 : "+e);
        }


        // is , as 구문
        Reptile rp = ani as Reptile; //익셉션 없이 안전하게 캐스팅 시도, 안될경우 null을 리턴
        if (rp == null) Debug.Log("rp 객체는 null입니다.");

        if(ani is Mammal) // ani객체가 mammal 타입으로 형변환 가능한지 체크하고 true, false를 리턴한다. 
        {
            Debug.Log("ani는 mammal 타입입니다.");
        }

        if(ani is Reptile)
        {
            Debug.Log("ani는 reptile 타입입니다.");
        }
        else
        {
            Debug.Log("ani는 reptile 타입이 아닙니다.");
        }


        Debug.Log("함수 종료시 출력되는 구문입니다.");
    }
}

public class Animal
{

}
public class Mammal : Animal
{

}

public class Reptile : Animal
{

}