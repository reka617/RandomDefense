using System;
using UnityEngine;

public class CastingSTudy : MonoBehaviour
{
    void Start()
    {
        // �Ͻ��� ����ȯ
        int i = 0;
        i = 10;
        short s = 10;
        i = s; // ����ȯ �Ͻ��� ����ȯ
        float f = i;
        //��κ� ���� �߸��ų� �ݿø����� �ʰ� ����� ������ �Ͻ��� ����ȯ����

        Animal ani = new Mammal(); // ��ӹ��� �θ� Ŭ����, �������̽��� �Ͻ��� ��ȯ �׻� ����

        // ����� ����ȯ
        s = (short)i; // int���� ���� Ÿ���� short �� ����ȯ
        i = (int)f;
        Mammal ma = (Mammal)ani; //�׳��� �ȵǴ� ��Ӱ����� ����ȯ
        //Mammal ma2 = (Mammal)new CastingSTudy(); // ��Ӱ��迡 ������ ����� ����ȯ�� �Ұ�

        //�Լ��� ���� ����ȯ
        string str = i.ToString();
        str = "���ڿ�";
        //Reptile rp = (Reptile)ani;
        try //try - catch ����
        {
            i = int.Parse(str);
        }
        catch(DivideByZeroException e) //� ���� 0���� �������� �õ������� �߻��ϴ� ����
        {
            Debug.LogError("�߻��� ������ : " + e);
        }
        catch(FormatException e) //��ȯ �Ϸ��� ������ ���� ������ ����
        {
            Debug.LogError("�߻��� ������ : " + e);
        }
        catch(NullReferenceException e) //�����Ϸ��� ��ü�� null�϶�
        {
            Debug.LogError("�߻��� ������ : " + e);
        }
        catch(InvalidCastException e) //����ȯ ����
        {
            Debug.LogError("�߻��� ������ : " + e);
        }
        catch(Exception e)
        {
            Debug.LogError("�߻��� ������ : "+e);
        }


        // is , as ����
        Reptile rp = ani as Reptile; //�ͼ��� ���� �����ϰ� ĳ���� �õ�, �ȵɰ�� null�� ����
        if (rp == null) Debug.Log("rp ��ü�� null�Դϴ�.");

        if(ani is Mammal) // ani��ü�� mammal Ÿ������ ����ȯ �������� üũ�ϰ� true, false�� �����Ѵ�. 
        {
            Debug.Log("ani�� mammal Ÿ���Դϴ�.");
        }

        if(ani is Reptile)
        {
            Debug.Log("ani�� reptile Ÿ���Դϴ�.");
        }
        else
        {
            Debug.Log("ani�� reptile Ÿ���� �ƴմϴ�.");
        }


        Debug.Log("�Լ� ����� ��µǴ� �����Դϴ�.");
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