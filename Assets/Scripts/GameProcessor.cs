using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameProcessor : MonoBehaviour
{
    // ���� �ӽ��� ������ ���� ���¸� ��������
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            MonsterManager.getInstance().AddMonster();
        }
    }
}
