using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorActions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CloseDoor();
    }

    public void OpenDoor()
    {
        transform.position = new Vector3(2.79f, 1.05f, 17.13f);
        transform.eulerAngles = new Vector3(- 0.001f, 90.047f, 0.972f);
    }
    public void CloseDoor()
    {
        transform.position = new Vector3(0, 1.05f, 14);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x,
        transform.eulerAngles.y + 180,
        transform.eulerAngles.z);
    }
}
