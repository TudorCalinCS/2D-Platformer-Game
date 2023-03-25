using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public Transform target;
    public float inaltimeCamera = 1f;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y+inaltimeCamera, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}
