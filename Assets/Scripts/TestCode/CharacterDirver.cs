using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDirver : MonoBehaviour
{
    [SerializeField] float _force;
    Rigidbody _rig;
    Collider _collider;
    private void Awake()
    {
        _rig= GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
    }

    void FixedUpdate()
    {
        if(Input.anyKey)
        {
            if(Input.GetMouseButton(0))
            {
                _rig.AddForce(Vector3.forward * _force);
            }
            if(Input.GetMouseButton(1))
            {
                _rig.AddForce(Vector3.back * _force);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name.Equals("ColliderWall"))
        {
            Debug.Log("충돌체크 들어옴");
            _collider.material.dynamicFriction = 150;
        }
    }
}
