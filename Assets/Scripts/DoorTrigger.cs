using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private DoorControl doorControl;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" ){
            doorControl.Operate();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" ){
            doorControl.Operate();
        }
    }
}
