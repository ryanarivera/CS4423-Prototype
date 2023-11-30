using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    
    //[SerializeField] AudioClip clip;

    void OnTriggerEnter2D(Collider2D other){
        //Destroy(this.gameObject);
        GetComponent<SpriteRenderer>().color = Color.red;
        other.GetComponent<Rigidbody2D>().velocity = other.GetComponent<Rigidbody2D>().velocity * -1;

        GetComponent<AudioSource>().pitch = Random.Range(.9f, 1.1f);
        GetComponent<AudioSource>().Play();
        //GetComponent<AudioSource>().PlayOneShot(clip); //allows audio to overlap instead of restart everytime
    }

    void OnTriggerExit2D(Collider2D other){

    }

    void OnTriggerStay2D(Collider2D other){
        
    }
}
