using UnityEngine;
using UnityEngine.Serialization;
public class BackgroundScrollTeleport : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    private Camera _mainCamera;
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private bool movingCamera = false;
    

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        
        if (!movingCamera) transform.Translate(Vector3.left * (speed * Time.deltaTime));
        
        var cameraPosition = _mainCamera.transform.position;
        var backgroundPosition = transform.position;
    
        var backgroundWidth = _spriteRenderer.bounds.size.x;
        var cameraHalfWidth = _mainCamera.orthographicSize * _mainCamera.aspect;
        var cameraLeft = cameraPosition.x - cameraHalfWidth;
        var backgroundRight = backgroundPosition.x + backgroundWidth / 2;
    
        if (cameraLeft > backgroundRight)
            transform.position = cameraPosition + new Vector3(cameraHalfWidth + (backgroundWidth / 2), 
                transform.position.y - cameraPosition.y, transform.position.z - cameraPosition.z);
    }
}