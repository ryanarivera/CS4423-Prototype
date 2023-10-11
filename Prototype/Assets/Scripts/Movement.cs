using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed = 100;
    Rigidbody2D rb;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    void Start(){

    }

    public void MoverTransform(Vector3 vel){
        transform.position += vel * speed * Time.deltaTime;
    }
    
    public void MoveRB(Vector3 vel){
        rb.velocity = vel * speed;
        //rb.MovePosition(transform.position + (vel * Time.fixedDeltaTime));
        //rb.AddForce(vel);
    }

    public void StepMove(Vector3 direction){
        transform.position += direction;
    }

}
