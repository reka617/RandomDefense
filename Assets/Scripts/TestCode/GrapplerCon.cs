using UnityEditor.Timeline;
using UnityEngine;

public class GrapplerCon : MonoBehaviour
{
    [SerializeField] float _speed;
    //카메라 컨트롤
    float rotX;
    float rotY;
    void Start()
    {
        rotX = transform.localRotation.eulerAngles.x;
        rotY = transform.localRotation.eulerAngles.y;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        rotX += Input.GetAxis("Mouse Y") * -1;
        rotY += Input.GetAxis("Mouse X");

        Quaternion rot = Quaternion.Euler(rotX,rotY,0);
        transform.rotation= rot;

        transform.Translate(new Vector3(moveX,0,moveY) * Time.deltaTime * _speed);
    }
}
