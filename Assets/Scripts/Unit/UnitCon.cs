using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class UnitCon : MonoBehaviour
{
    [SerializeField] GameObject _marker;
    EUnitType _eType;
    NavMeshAgent _agent;
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }
    public void Init(EUnitType eType)
    {
        _eType = eType;
    }
    public EUnitType getUnitType()
    {
        return _eType;
    }
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

}
