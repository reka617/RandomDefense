using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Utils;

public class UnitCon : MonoBehaviour
{
    [SerializeField] GameObject _marker;
    EUnitType _eType;
    NavMeshAgent _agent;
    UnitState _state; 
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }
    public void Init(EUnitType eType)
    {
        _eType = eType;
    }
    public EUnitType getUnitType { get{ return _eType;}}
    public void SelectUnit()
    {
        _marker.SetActive(true);
    }

    public void DeSelectUnit()
    {
        _marker.SetActive(false);
    }

    public void MoveTo(Vector3 dest)
    {
        _agent.SetDestination(dest);
    }

    private void Update()
    {
        if (_state == null) _state = new UnitSearchState();
        if(_state != null) _state.MainLoop();
        Debug.Log("현재 상태 :" + _state);
    }

    public void ChangeUnitState(UnitState state)
    {
        _state = state;
        if (_state != null) _state.OnEnter(this);
    }

    public bool isMoveEnd()
    {
        if (_agent.remainingDistance < -0) return true;
        return false;
    }
}

public class UnitState
{
    protected UnitCon _unit;
    public virtual void OnEnter(UnitCon unit)
    {
        _unit = unit;

    }

    public virtual void MainLoop() 
    {

    }


}

