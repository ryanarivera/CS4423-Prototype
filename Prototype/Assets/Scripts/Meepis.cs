using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meepis : MonoBehaviour
{

    [SerializeField] int hp = 3;
    //[SerializeField] float stamina = 10.0f;
    //[SerializeField] string meepisName = "Meepis";
    [SerializeField] GameObject stick;
    [SerializeField] float speed = 1;


    void Awake(){

    }

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Hello! This is Meepis");
        CopyStickColor();
    }

    // Update is called once per frame
    void Update()
    {
        

        if(Input.GetKey(KeyCode.D)){
            //Get Component<Transform>()
            transform.position += new Vector3(speed*Time.deltaTime,0,0);
        }

        if(Input.GetKey(KeyCode.A)){
            //Get Component<Transform>()
            transform.position -= new Vector3(speed*Time.deltaTime,0,0);
        }

        if(Input.GetKey(KeyCode.Q)){
            
            transform.localScale *= 1 + (.5f * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.W)){
            //Get Component<Transform>()
            transform.position += new Vector3(0,speed*Time.deltaTime,0);
        }

        if(Input.GetKey(KeyCode.S)){
            //Get Component<Transform>()
            transform.position -= new Vector3(0,speed*Time.deltaTime,0);
        }

    }

    //set the stick color to match meepis
    public void CopyStickColor(){
        stick.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;;
    }

    public int GetHP(){
        return hp;
    }

}
