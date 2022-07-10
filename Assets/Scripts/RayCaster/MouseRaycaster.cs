using UnityEngine;

namespace RayCaster
{
    public class MouseRaycaster : MonoBehaviour
    {
        [SerializeField] private Transform debugPoint;
        private Camera _camera;

        //todo camera provider
        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            var mousePos = Input.mousePosition;
            Ray ray = _camera.ScreenPointToRay(mousePos);

            if (Physics.Raycast(ray, out RaycastHit info))
                debugPoint.position = info.point;
        }
    }
}