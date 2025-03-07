using UnityEngine;
using UnityEngine.UIElements;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float speed = 50f;

    void Start()
    {
        
    }


    void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
}
