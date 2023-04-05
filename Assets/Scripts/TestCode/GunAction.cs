using TMPro.EditorUtilities;
using TMPro.SpriteAssetUtilities;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class GunAction : MonoBehaviour
{
    [SerializeField] Transform _playerBase;
    Camera _cam;
    LineRenderer _lRenderer;
    SpringJoint _sJoint;
    RaycastHit hit;
    bool _isDraw = false;
    // 1. 캐릭터의 중심에서 레이캐스트를 해서 충돌한 블럭을 체크
    // 2. 충돌한 지점 까지 선을 연결해서 그린다. -> 런타임에서 실시간으로 그림그리기.
    // 3. 충돌한 지점에 스프링조인트 연결해서 끌어 당겨진다. 
    // 4. 런타임에서 생성한 스프링조인트를 파괴/삭제한다.

    void Start()
    {
        _cam = Camera.main;
        _lRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GunFire();
        }
        if(Input.GetMouseButtonUp(0))
        {
            EndFire();
        }
        drawLine();
    }

    void drawLine()
    {
        if (_isDraw == false) return;
        _lRenderer.positionCount = 2;
        _lRenderer.SetPosition(0, transform.position);
        _lRenderer.SetPosition(1, hit.point);
    }

    void GunFire()
    {
        Debug.DrawRay(_cam.transform.position, _cam.transform.forward* 50, Color.red, 5f);
        if(Physics.Raycast(_cam.transform.position, _cam.transform.forward, out hit, 50, 1 << LayerMask.NameToLayer("TargetBlock")))
        {
            _isDraw = true;
            _sJoint = _playerBase.gameObject.AddComponent<SpringJoint>();
            _sJoint.autoConfigureConnectedAnchor = false;
            _sJoint.connectedAnchor = hit.point;
            _sJoint.maxDistance = hit.distance;
            _sJoint.minDistance = hit.distance * 0.5f;
            _sJoint.spring = 300;
        }
    }
    void EndFire()
    {
        _isDraw = false;
        _lRenderer.positionCount = 0;
        Destroy(_sJoint);
    }
}
