using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    // public float speed;
    // Rigidbody2D rBody;

    // Start is called before the first frame update
    // void Start()
    // {
    //     rBody = GetComponent<Rigidbody2D>();
    // }

    // // Update is called once per frame
    // void FixedUpdate()
    // {
    //     Vector2 pos = rBody.position;
    //     rBody.position += Vector2.left * speed * Time.fixedDeltaTime;
    //     rBody.MovePosition(pos);
    // }

    // public float speed;
    // public float resetPositionX; // The position at which the object should be reset.
    // Rigidbody2D rBody;

    // // Start is called before the first frame update
    // void Start()
    // {
    //     rBody = GetComponent<Rigidbody2D>();
    // }

    // // Update is called once per frame
    // void FixedUpdate()
    // {
    //     Vector2 pos = rBody.position;
    //     pos += Vector2.left * speed * Time.fixedDeltaTime;
    //     //rBody.MovePosition(pos);

    //     // Check if the object has moved beyond the reset point
    //     if (pos.x <= resetPositionX)
    //     {
    //         // Reset the object's position to its initial position
    //         rBody.MovePosition(new Vector2(transform.position.x, transform.position.y));
    //     }
    // }

    public float speed = 1.0f;
    public ForceMode2D forceMode = ForceMode2D.Force; // Use Impulse for instant response.

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Make sure the player has the "Player" tag.
        {
            Rigidbody2D playerRigidbody = other.GetComponent<Rigidbody2D>();
            Vector2 force = new Vector2(speed, 0);
            playerRigidbody.AddForce(force, forceMode);
        }
    }

}
