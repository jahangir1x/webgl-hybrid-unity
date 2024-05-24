
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 CameraOffset;

    [Range(0.01f , 1.0f)]
    public float smoothness = .5f;
    // Start is called before the first frame update
    void Start()
    {
        CameraOffset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = player.position + CameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, smoothness);
    }
}
