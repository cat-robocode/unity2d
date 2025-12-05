using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 1f;
    private Transform _target;

    private void Start()
    {
        _target = FindFirstObjectByType<PlayerController>().GetComponent<Transform>();
    } 
    private void Update()
    {
        if(_target.position.y > gameObject.transform.position.y)
        {
            Vector3 newPos = new Vector3(transform.position.x, _target.position.y, transform.position.z);
            //gameObject.transform.position = Vector3.Lerp(transform.position, newPos, speed);

            transform.position = newPos;

        }
    }
}
