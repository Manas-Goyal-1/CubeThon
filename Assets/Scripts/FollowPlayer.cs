using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
		// Doesn't rotate right now
        transform.position = player.position + offset;
    }
}
