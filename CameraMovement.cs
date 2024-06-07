using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //public GameObject player;
    public Transform player;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {

        //   transform.position = new Vector3(player.transform.position.x, transform.position.y, -10);
        Vector3 newPosition = player.position + offset;
        newPosition.z = transform.position.z; // Maintain the camera's original z position
        transform.position = newPosition;
    }
}

