using UnityEngine;

public class CameraRunnerScript : MonoBehaviour
{

    public Transform player;
    public Vector3 offset;

    void FixedUpdate()
    {
        transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y,
                offset.z); // Camera follows the player with specified offset position
    }
}