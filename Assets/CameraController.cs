using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
    private CinemachineTransposer _transposer;
    private const float MinFollowYOffset = 2f;
    private const float MaxFollowYOffset = 8f;
    private Vector3 _targetFollowOffset;

    private void Awake()
    {
        _transposer = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        _targetFollowOffset = _transposer.m_FollowOffset;
    }

    void Update()
    {
        //refactor this shit
        HandleMovement();
        HandleRotation();
        HandleZoom();
    }

    private void HandleMovement()
    {
        Vector3 inputMoveDir = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            inputMoveDir.z = +1f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            inputMoveDir.z = -1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            inputMoveDir.x = -1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            inputMoveDir.x = +1f;
        }

        Vector3 moveVector = transform.forward * inputMoveDir.z + transform.right * inputMoveDir.x;
        float moveSpeed = 5f; //make variable from config
        transform.position += moveVector * (moveSpeed * Time.deltaTime);
    }

    private void HandleRotation()
    {
        Vector3 rotationVector = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.Q))
        {
            rotationVector.y = +1f;
        }

        if (Input.GetKey(KeyCode.E))
        {
            rotationVector.y = -1f;
        }

        float rotationSpeed = 50f; //make variable from config
        transform.eulerAngles += rotationVector * (rotationSpeed * Time.deltaTime);
    }

    private void HandleZoom()
    {
        float zoomAmount = 1f; //make variable from config
        float zoomSpeed = 5f; //make variable from config
        _targetFollowOffset = _transposer.m_FollowOffset;

        if (Input.mouseScrollDelta.y > 0)
            _targetFollowOffset.y -= zoomAmount;
        if (Input.mouseScrollDelta.y < 0)
            _targetFollowOffset.y += zoomAmount;

        _targetFollowOffset.y = Mathf.Clamp(_targetFollowOffset.y, MinFollowYOffset, MaxFollowYOffset);
        _transposer.m_FollowOffset =
            Vector3.Lerp(_transposer.m_FollowOffset, _targetFollowOffset, Time.deltaTime * zoomSpeed);
    }
}