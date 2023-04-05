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
    // 1. ĳ������ �߽ɿ��� ����ĳ��Ʈ�� �ؼ� �浹�� ���� üũ
    // 2. �浹�� ���� ���� ���� �����ؼ� �׸���. -> ��Ÿ�ӿ��� �ǽð����� �׸��׸���.
    // 3. �浹�� ������ ����������Ʈ �����ؼ� ���� �������. 
    // 4. ��Ÿ�ӿ��� ������ ����������Ʈ�� �ı�/�����Ѵ�.

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
