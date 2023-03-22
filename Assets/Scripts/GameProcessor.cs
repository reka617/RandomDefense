using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameProcessor : MonoBehaviour
{
    // 상태 머신을 가져서 게임 상태를 관리해줌
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            MonsterManager.getInstance().AddMonster();
        }
    }
}
