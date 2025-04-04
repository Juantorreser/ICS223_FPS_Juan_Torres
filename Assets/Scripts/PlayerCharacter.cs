using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public int health;
    public int maxHealth = 5;

    // Use this for initialization
    void Start()
    {
        health = maxHealth;
    }
    public void Hit()
    {
        health -= 1;
        health = Mathf.Max(health, 0);

        float percent = (float)health / maxHealth;
        Messenger<float>.Broadcast(GameEvent.HEALTH_CHANGED, percent);

        Debug.Log("Health: " + health);
        if (health == 0)
        {
            Debug.Break();
        }
    }
}
