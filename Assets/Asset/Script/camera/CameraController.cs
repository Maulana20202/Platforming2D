using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;         
    public float smoothSpeed = 0.125f; 
    public Vector2 minBounds;        
    public Vector2 maxBounds;        

    private void LateUpdate()
    {

        
        Vector3 desiredPosition = new Vector3(player.position.x, transform.position.y, transform.position.z);

        
        float clampedX = Mathf.Clamp(desiredPosition.x, minBounds.x, maxBounds.x);
        Vector3 clampedPosition = new Vector3(clampedX, desiredPosition.y, desiredPosition.z);

        
        transform.position = clampedPosition;
    }
}
