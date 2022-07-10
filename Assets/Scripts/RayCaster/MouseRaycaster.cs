using UnityEngine;

namespace RayCaster
{
    public class MouseRaycaster : MonoBehaviour
    {
        [SerializeField] private Transform debugPoint;
        [SerializeField] private string[] layers;
        [SerializeField] private LayerMask layerMask;
        [SerializeField, Range(0, 100f)] private float rayCastLenght = 50f;
        private Camera _camera;
        private Plane _plane;

        //todo camera provider
        private void Awake()
        {
            layerMask = LayerMask.GetMask(layers);
            _plane = new Plane(Vector3.up, Vector3.zero);
            _camera = Camera.main;
        }

        private void Update()
        {
            var mousePos = Input.mousePosition;
            Ray ray = _camera.ScreenPointToRay(mousePos);

            if (_plane.Raycast(ray, out float enter))
            {
                debugPoint.position = ray.GetPoint(enter);
            }
        }

        private void FakeUpdate()
        {
            var mousePos = Input.mousePosition;
            Ray ray = _camera.ScreenPointToRay(mousePos);

            if (Physics.Raycast(ray, out RaycastHit info, rayCastLenght, layerMask))
            {
                debugPoint.position = ray.GetPoint(rayCastLenght);
            }
        }
    }
}