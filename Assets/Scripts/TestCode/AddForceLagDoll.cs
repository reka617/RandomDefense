using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceLagDoll : MonoBehaviour
{
    [SerializeField] Rigidbody _rig; // pelvis // spine2// left hip

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            _rig.AddForce(Vector3.back * 30 + Vector3.up * 10, ForceMode.Impulse);
            Time.timeScale = 0.1f;
        }
    }
}
