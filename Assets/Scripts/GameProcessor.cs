using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameProcessor : MonoBehaviour
{
    GameState _state;
    private void Start()
    {
        ChangeGameState(new DefenseRunning());
    }
    // 상태 머신을 가져서 게임 상태를 관리해줌
    void Update()
    {
        if(_state != null)_state.MainLoop();
        
    }
    public void ChangeGameState(GameState state)
    {
        _state = state;
    }
}

public class GameState
{
    public virtual void MainLoop()
    {

    }
}