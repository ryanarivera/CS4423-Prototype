using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInputHandler : MonoBehaviour
{
    
    //[SerializeField] Movement movement;
    //PointsHandler pointsHandler;
    //ProjectileThrower projectileThrower;
    
    public float speed = 5f;
    public float jumpSpeed = 10f;
    private float direction = 0f;
    private Rigidbody2D player;

    private AudioSource audioSource;
    public AudioClip pointHitSound;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;
    public string mainMenuSceneName = "MainMenu";
    public string gameScene = "GameScene";
    private static PointsHandler pointsHandler;
    public static PlayerInputHandler _instance;
    [SerializeField] AnimationStateChanger animationStateChanger;
    [SerializeField] Transform body;

    public static PlayerInputHandler Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PlayerInputHandler>();

                if (_instance == null)
                {
                    Debug.LogError("PlayerInputHandler is not in the scene.");
                }
            }

            return _instance;
        }
    }

    void Awake(){
        //pointsHandler = GameObject.Find("PointsHandler").GetComponent<PointsHandler>();
        //pointsHandler = GameObject.FindObjectOfType<PointsHandler>(); NO NOT USE THIS, VERY SLOW!! O(n*m)
        //pointsHandler = GameObject.FindGameObjectWithTag("PointsHandler").GetComponent<PointsHandler>();
        //USE THIS ONE
        //projectileThrower = GetComponent<ProjectileThrower>();
    }

    void Start(){
        //pointsHandler = PointsHandler.singleton; //the second fasted option
        audioSource = GetComponent<AudioSource>();

        player = GetComponent<Rigidbody2D>();
        pointsHandler = PointsHandler.singleton;
    }

    void FixedUpdate(){
        /*Vector3 vel = Vector3.zero;
        if(Input.GetKey(KeyCode.W)){
            vel.y = 1;
        }if(Input.GetKey(KeyCode.S)){
            vel.y = -1;
        }if(Input.GetKey(KeyCode.A)){
            vel.x = -1;
        }if(Input.GetKey(KeyCode.D)){
            vel.x = 1;
        }*/
        
        //NEED ONE OF THESE IF USING CODE ABOVE FOR MOVEMENT
        //movement.MoverTransform(vel);
        //movement.MoveRB(vel);
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
        /*if(Input.GetKeyDown(KeyCode.Q)){
            projectileThrower.Throw(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }*/

        //NEW CODE TO MAKE PLAYER MOVE AND JUMP
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        direction = Input.GetAxis("Horizontal");

        if (direction > 0f)
        {
            body.localScale = new Vector3(3,3,1);
            animationStateChanger.ChangeAnimationState("WalkMeepis");
            player.velocity = new Vector2(direction * speed, player.velocity.y);
        }
        else if (direction < 0f)
        {
            body.localScale = new Vector3(-3,3,1);
            animationStateChanger.ChangeAnimationState("WalkMeepis");
            player.velocity = new Vector2(direction * speed, player.velocity.y);
        }else if (direction == 0f)
        {
            animationStateChanger.ChangeAnimationState("IdleMeepis");
            //player.velocity = new Vector2(direction * speed, player.velocity.y);
        }
        else
        {
            player.velocity = new Vector2(0, player.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("points"))
        {
            // Play the point hit sound
            audioSource.PlayOneShot(pointHitSound);

            pointsHandler.IncreaseScore(1);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("PlusSpeed"))
        {
            // Play the point hit sound
            audioSource.PlayOneShot(pointHitSound);

            this.speed += 5f;
            pointsHandler.DecreaseScore(5);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("PlusJump"))
        {
            // Play the point hit sound
            audioSource.PlayOneShot(pointHitSound);

            this.jumpSpeed += 2f;
            pointsHandler.DecreaseScore(5);
            Destroy(other.gameObject);
        }

        // Check if the collision is with an obstacle
        if (other.gameObject.CompareTag("obstacle"))
        {
            // Destroy the player GameObject
            
            //Destroy(gameObject);
            SceneManager.LoadScene("MainMenu");
            //pointsHandler.ClearScore();
        }

        if (other.gameObject.CompareTag("Door"))
        {
            // Destroy the player GameObject
            pointsHandler.SaveScore();
            //Destroy(gameObject);
            SceneManager.LoadScene("Shop1");
        }

    }

    public void IncreasePlayerSpeed(float speedIncrease)
    {
        speed += speedIncrease;
    }

}
