using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsHandler : MonoBehaviour
{
    [SerializeField] float distanceTranveled = 0f;
    public static PointsHandler singleton;

    void Awake(){
        if(singleton == null){
            singleton = this;
        }else{
            Destroy(this.gameObject);
        }
    }

    public void AddDistance(float d){
        distanceTranveled += d;
    }

}
