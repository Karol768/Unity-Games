using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartPoint : MonoBehaviour
{
    RestartPointsController restartPointsController;
    SpriteRenderer spriteRend;
    public AudioClip clip;
    Collider2D collid;

    // Start is called before the first frame update
    void Start()
    {
        collid = GetComponent<Collider2D>();
        spriteRend = GetComponent<SpriteRenderer>(); 
        restartPointsController = GameObject.Find("Manager").GetComponent<RestartPointsController>();
        if (restartPointsController == null)
        {
            Debug.LogError("RestartPointsController not found");
        } 
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            restartPointsController.UpdateRestartPoint(this.gameObject.transform);
            spriteRend.color = new Color(0.3f, 0.6f, 0.6f);
            AudioSource.PlayClipAtPoint(clip, transform.position);
            this.collid.enabled = false;
        }
    }
}
