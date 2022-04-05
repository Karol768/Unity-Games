using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftsPickUp : MonoBehaviour
{
    Score scoreController;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        scoreController = GameObject.Find("Manager").GetComponent<Score>();
        if(scoreController == null)
        {
            Debug.LogError("ScoreController not found");
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.name == "Player")
        {
            Destroy(this.gameObject);
            AudioSource.PlayClipAtPoint(clip, transform.position);
            scoreController.IncrementScore();
        }
    }
}
