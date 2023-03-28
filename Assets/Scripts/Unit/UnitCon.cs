using System.Collections;
using System.Collections.Generic;
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
    
    public void SelectUnit()
    {
        _marker.SetActive(true);
    }

    public void DeselectUnit()
    {
        _marker.SetActive(false);
    }

    public void MoveTo(Vector3 dest)
    {
        _agent.SetDestination(dest);
    }

    

    
    public EUnitType GetUnitType() 
    {
        return _eType; 
    }

}
