using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    float heightOffset;

    void Start()
    {
        player = GameMaster.instance.player.gameObject;
        heightOffset = transform.position.z - player.transform.position.z;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + heightOffset * Vector3.forward;
    }
}
