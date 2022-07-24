using UnityEngine;

namespace RayCaster
{
    public class MouseRaycaster : MonoBehaviour
    {
        [SerializeField] private Transform debugPoint;
        [SerializeField] private string[] layers;
        // [SerializeField] private LayerMask layerMask;
        // [SerializeField, Range(0, 100f)] private float rayCastLenght = 50f;
        private Camera _camera;
        private Plane _plane;

        public static MouseRaycaster Instance;
        //todo camera provider
        private void Awake()
        {
            Instance = this;
            // layerMask = LayerMask.GetMask(layers);
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

        public bool TryGetPosition(out Vector3 position)
        {
            position = Vector3.zero;
            var mousePos = Input.mousePosition;
            var ray = _camera.ScreenPointToRay(mousePos);

            if (!_plane.Raycast(ray, out float enter)) return false;
            position = ray.GetPoint(enter);
            debugPoint.position = position;
            return true;
        }
    }
}