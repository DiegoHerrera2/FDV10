using UnityEngine;
public class CameraScroll : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    private void Update()
    {
        transform.Translate(Vector3.right * (speed * Time.deltaTime));
    }
}