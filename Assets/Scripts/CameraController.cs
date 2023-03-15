using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float speed;
    [SerializeField] private float yOffset;
    [SerializeField] private float zOffset;
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x, yOffset, player.transform.position.z + zOffset), speed * Time.deltaTime);
    }
}
