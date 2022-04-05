using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalPlatform : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private Vector2 endPoint;
    public Transform navEndPoint;
    private bool playerOnPlatform = false;

    // Start is called before the first frame update
    void Start()
    {
        endPoint = navEndPoint.position;
        Destroy(navEndPoint.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Finish();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerOnPlatform = true;
            other.transform.parent = transform;
            other.attachedRigidbody.Sleep();
        }
    }

    void Finish()
    {
        if(playerOnPlatform)
        {
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            transform.position = Vector2.MoveTowards(transform.position, endPoint, speed * Time.deltaTime);
        }

        if(gameObject.transform.position.y>10.0f)
        {
            SceneManager.LoadScene("LevelCompleted");
        }
    }
}
