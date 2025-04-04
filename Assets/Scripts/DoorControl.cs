using UnityEngine;

public class DoorControl : MonoBehaviour
{
    private bool doorIsOpen = false;
    private Vector3 homePos;
    private Vector3 closeOffset = new Vector3(0, 0, -3);
    private float moveTime = 2.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        homePos = transform.position;
    }
    public void Operate()
    {
        if (doorIsOpen)
        {
            iTween.MoveTo(this.gameObject, homePos, moveTime);
        }
        else
        {
            iTween.MoveTo(this.gameObject, homePos + closeOffset, moveTime);
        }
        doorIsOpen = !doorIsOpen;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
