using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public float smooth;
    private Vector3 currentVelocity;


    // Update is called once per frame
    void Update()
    {
        Vector3 newCameraPosition = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, newCameraPosition, ref currentVelocity, smooth);
    }
}
