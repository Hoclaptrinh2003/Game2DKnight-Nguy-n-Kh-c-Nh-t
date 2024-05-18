

using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    public Transform player;
    public float smoothing;
    Vector3 offset;
    float lowY;
   
    void Start()
    {
        offset = transform.position-player.position;
        lowY = transform.position.y;
    }

    
    void FixedUpdate()
    {
        Vector3 playerCamPos = player.position+offset;
        transform.position = Vector3.Lerp (transform.position, playerCamPos,smoothing*Time.deltaTime);
    }
}
