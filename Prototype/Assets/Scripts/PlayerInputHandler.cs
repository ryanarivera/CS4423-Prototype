using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    
    [SerializeField] Movement movement;
    PointsHandler pointsHandler;
    ProjectileThrower projectileThrower;

    private AudioSource audioSource;
    public AudioClip pointHitSound;

    void Awake(){
        //pointsHandler = GameObject.Find("PointsHandler").GetComponent<PointsHandler>();
        //pointsHandler = GameObject.FindObjectOfType<PointsHandler>(); NO NOT USE THIS, VERY SLOW!! O(n*m)
        //pointsHandler = GameObject.FindGameObjectWithTag("PointsHandler").GetComponent<PointsHandler>();
        projectileThrower = GetComponent<ProjectileThrower>();
    }

    void Start(){
        pointsHandler = PointsHandler.singleton; //the second fasted option

        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate(){
        Vector3 vel = Vector3.zero;
        if(Input.GetKey(KeyCode.W)){
            vel.y = 1;
        }if(Input.GetKey(KeyCode.S)){
            vel.y = -1;
        }if(Input.GetKey(KeyCode.A)){
            vel.x = -1;
        }if(Input.GetKey(KeyCode.D)){
            vel.x = 1;
        }
        //movement.MoverTransform(vel);
        movement.MoveRB(vel);
        //pointsHandler.AddDistance(vel.magnitude * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        /*Vector3 vel = Vector3.zero;              //This code makes player move one unit at a time
        if(Input.GetKeyDown(KeyCode.W)){
            movement.StepMove(new Vector3(0,1,0));
        }if(Input.GetKeyDown(KeyCode.S)){
            movement.StepMove(new Vector3(0,-1,0));
        }if(Input.GetKeyDown(KeyCode.A)){
            movement.StepMove(new Vector3(-1,0,0));
        }if(Input.GetKeyDown(KeyCode.D)){
            movement.StepMove(new Vector3(1,0,0));
        }*/

        //projectiles
        if(Input.GetKeyDown(KeyCode.Q)){
            projectileThrower.Throw(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("points"))
        {
            // Play the point hit sound
            audioSource.PlayOneShot(pointHitSound);

            // Handle other logic related to point collection
            // For example, increment the player's score or destroy the point object.
        }
    }


}