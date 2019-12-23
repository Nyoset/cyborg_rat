using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform playerTransform;
    float heightOffset;

    void Start()
    {
        playerTransform = GameMaster.instance.player?.transform ?? transform;
        heightOffset = transform.position.z - playerTransform.position.z;
    }

    void LateUpdate()
    {
        transform.position = playerTransform.position + heightOffset * Vector3.forward;
    }
}
