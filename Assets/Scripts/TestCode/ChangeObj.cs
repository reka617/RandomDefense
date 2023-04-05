using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObj : MonoBehaviour
{

    [SerializeField] GameObject _normalObj;
    [SerializeField] GameObject _ragdollObj;

    [SerializeField] Rigidbody _rig;

   
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ChangeObject();
        }
    }

    void ChangeObject()
    {
        Time.timeScale = 0.1f;
        _normalObj.SetActive(false);
        _ragdollObj.SetActive(true);
        _rig.AddForce(Vector3.back * 200 + Vector3.up * 300, ForceMode.Impulse);
        
    }
}
