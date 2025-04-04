using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    public float rotationSpeed = 180f;
    private int value = 1;

    void Update()
    {
        // Rotate around the world's Y-axis at the given speed
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Messenger<int>.Broadcast(GameEvent.PICKUP_HEALTH, value);
            Destroy(this.gameObject);
        }
    }
}
