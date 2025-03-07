using UnityEngine;

public class Hole : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Detect collisions with other objects
     void OnCollisionEnter(Collision collision)
    {
        // Check if the object of collision has the tag "Ball"
        if (collision.gameObject.tag == "Ball")
        {
            // Destroy the object (Ball)
            Destroy(collision.gameObject);
        }
    }
}
