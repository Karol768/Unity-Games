using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    public Transform navStartPoint, navEndPoint;
    private Vector2 startPoint, endPoint;
    private Vector2 currentPos;

    void Start()
    {
        startPoint = navStartPoint.position;
        endPoint = navEndPoint.position;
        Destroy(navStartPoint.gameObject);
        Destroy(navEndPoint.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = Vector2.Lerp(startPoint, endPoint, Mathf.PingPong(Time.time*speed, 1));
        transform.position = currentPos;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.transform.parent = transform;
            other.attachedRigidbody.Sleep();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.transform.parent = null;
        }   
    }
}
