using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanController : MonoBehaviour
{
    public AudioClip clip;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.name == "Player")
        {
            AudioSource.PlayClipAtPoint(clip, transform.position);
            other.gameObject.GetComponent<Animator>().SetTrigger("hurt");
        }
    }
}
